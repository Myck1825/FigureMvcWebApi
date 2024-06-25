-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
USE FigureDb
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE sp_Intersect_Procedure 
	-- Add the parameters for the stored procedure here
	@x1 INT, @y1 INT,
	@x2 INT, @y2 INT, 
	@skip INT, @take INT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @count INT

	SET @count = (
	select 	SUM(COALESCE(ab.CountRowAB, bd.CountRowBD, dc.CountRowDC, ca.CountRowCA)) as CountRow
	from 
	-- segment AB
	(SELECT COUNT(r.Id) as CountRowAB,
	r.PointAId, pA.X as PointA_X, pA.Y as PointA_Y,
	r.PointBId, pB.X as PointB_X, pB.Y as PointB_Y
	from dbo.Rectangles as r 
	left join  dbo.Points as pA
	on r.PointAId = pA.Id
	left join dbo.Points as pB
	on r.PointBId = pb.Id
	group by r.PointAId, r.PointBId, pA.X, pA.Y, pB.X, pB.Y
	having 
	dbo.IsIntersect(@x1, @y1, @x2, @y2, pA.X, pA.Y, pB.X, pB.Y) = 1) as ab
	
	-- segment BD
	full outer join
	(SELECT COUNT(r.Id) as CountRowBD,
	r.PointBId, pB.X as PointB_X, pB.Y as PointB_Y,
	r.PointDId, pD.X as PointD_X, pD.Y as PointD_Y
	from dbo.Rectangles as r 
	left join dbo.Points as pB
	on r.PointBId = pb.Id
	left join  dbo.Points as pD
	on r.PointDId = pD.Id
	group by r.PointBId, r.PointDId, pB.X, pB.Y, pD.X, pD.Y
	having 
	dbo.IsIntersect(@x1, @y1, @x2, @y2, pB.X, pB.Y, pD.X, pD.Y) = 1) as bd
	on ab.PointBId = bd.PointBId
	
	-- segment DC
	full outer join
	(SELECT COUNT(r.Id) as CountRowDC,
	r.PointDId, pD.X as PointD_X, pD.Y as PointD_Y,
	r.PointCId, pC.X as PointC_X, pC.Y as PointC_Y
	from dbo.Rectangles as r 
	left join  dbo.Points as pD
	on r.PointDId = pD.Id
	left join dbo.Points as pC
	on r.PointCId = pC.Id
	group by r.PointDId, r.PointCId, pD.X, pD.Y, pC.X, pC.Y
	having 
	dbo.IsIntersect(@x1, @y1, @x2, @y2, pD.X, pD.Y, pC.X, pC.Y) = 1) as dc
	on bd.PointDId = dc.PointDId
	
	-- segment CA
	full outer join
	(SELECT COUNT(r.Id) as CountRowCA,
	r.PointCId, pC.X as PointC_X, pC.Y as PointC_Y,
	r.PointAId, pA.X as PointA_X, pA.Y as PointA_Y
	from dbo.Rectangles as r 
	left join dbo.Points as pC
	on r.PointCId = pC.Id
	left join  dbo.Points as pA
	on r.PointAId = pA.Id
	group by r.PointCId, r.PointAId, pC.X, pC.Y, pA.X, pA.Y
	having 
	dbo.IsIntersect(@x1, @y1, @x2, @y2, pC.X, pC.Y, pA.X, pA.Y) = 1) as ca
	on dc.PointCId = ca.PointCId)

	SET @take = case when @take = 0 then @count - @skip when @take > 0 then @take end

    -- Select rectngles whitch is intersect input segment
	SELECT @count as CountRow, r.Id, 
	r.PointAId, pA.X as PointA_X, pA.Y as PointA_Y,
	r.PointBId, pB.X as PointB_X, pB.Y as PointB_Y,
	r.PointDId, pD.X as PointD_X, pD.Y as PointD_Y,
	r.PointCId, pC.X as PointC_X, pC.Y as PointC_Y
	from dbo.Rectangles as r 
	left join  dbo.Points as pA
	on r.PointAId = pA.Id
	left join dbo.Points as pB
	on r.PointBId = pB.Id
	left join dbo.Points as pC
	on r.PointCId = pC.Id
	left join dbo.Points as pD
	on r.PointDId = pD.Id
	where 
	 dbo.IsIntersect(@x1, @y1, @x2, @y2, pA.X, pA.Y, pB.X, pB.Y) = 1
	OR dbo.IsIntersect(@x1, @y1, @x2, @y2, pB.X, pB.Y, pD.X, pD.Y) = 1
	OR dbo.IsIntersect(@x1, @y1, @x2, @y2, pD.X, pD.Y, pC.X, pC.Y) = 1
	OR dbo.IsIntersect(@x1, @y1, @x2, @y2, pC.X, pC.Y, pA.X, pA.Y) = 1
	order by r.Id
	OFFSET (@skip) ROWS FETCH NEXT (@take) ROWS ONLY
END
GO
