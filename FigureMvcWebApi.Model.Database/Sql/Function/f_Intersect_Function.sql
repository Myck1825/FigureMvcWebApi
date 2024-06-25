-- ================================================
-- Template generated from Template Explorer using:
-- Create Scalar Function (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the function.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE OR ALTER FUNCTION dbo.IsIntersect 
(
	-- Add the parameters for the function here
	@x1 int, @y1 int,
	@x2 int, @y2 int,
	@x3 int, @y3 int,
	@x4 int, @y4 int
)
RETURNS bit
AS
BEGIN
	-- Declare the return variable here
	DECLARE @isintersect bit

	DECLARE @x12 int, @x34 int, @y12 int, @y34 int, @c int, @a int, @b int, @x float(2), @y float(2)

	SET @x12 = @x1 - @x2;
	SET @x34 = @x3 - @x4;
	SET @y12 = @y1 - @y2;
	SET @y34 = @y3 - @y4;

	SET @c = @x12 * @y34 - @y12 * @x34

	IF(@c = 0)
		RETURN 0

	SET @a = @x1 * @y2 - @y1 * @x2
	SET @b = @x3 * @y4 - @y3 * @x4

	SET @x = (@a * @x34 - @b * @x12) / CAST(@c as float)
	SET @y = (@a * @y34 - @b * @y12) / CAST(@c as float)

	if(@x >= (select CASE WHEN @x1 <= @x2 THEN @x1 ELSE @x2 END) AND @x <= (select CASE WHEN @x1 >= @x2 THEN @x1 ELSE @x2 END)
	AND @x >= (select CASE WHEN @x3 <= @x4 THEN @x3 ELSE @x4 END) AND @x <= (select CASE WHEN @x3 >= @x4 THEN @x3 ELSE @x4 END)
	AND @y >= (select CASE WHEN @y1 <= @y2 THEN @y1 ELSE @y2 END) AND @y <= (select CASE WHEN @y1 >= @y2 THEN @y1 ELSE @y2 END)
	AND @y >= (select CASE WHEN @y3 <= @y4 THEN @y3 ELSE @y4 END) AND @y <= (select CASE WHEN @y3 >= @y4 THEN @y3 ELSE @y4 END))
		SET @isintersect = 1
	ELSE
		SET @isintersect = 0


	-- Return the result of the function
	RETURN @isintersect

END
GO