using FigureMvcWebApi.Model.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace FigureMvcWebApi.Model.Database.Services
{
    /// <summary>
    /// Base service.
    /// </summary>
    public abstract class BaseService
    {
        protected const string ModelIsNotValidErrorMessage = "Model Is Not Valid.";

        /// <summary>
        /// Bases the invoke.
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="action">Action.</param>
        /// <param name="callerName">Caller name.</param>
        /// <param name="callerFile">Caller file.</param>
        /// <param name="callerLineNumber">Caller line number.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        protected async Task<AOResult<T>> BaseInvokeAsync<T>(Func<AOResult<T>, Task> func, object request = null, [CallerMemberName] string callerName = null, [CallerFilePath] string callerFile = null, [CallerLineNumber] int callerLineNumber = 0)
        {
            AOResult<T> aoResult = new AOResult<T>(callerName, callerFile, callerLineNumber);
            try
            {
                List<ValidationResult> checkModelAOResult = CheckRequest(request);

                if (checkModelAOResult.Any())
                {
                    aoResult.SetError(ModelIsNotValidErrorMessage, checkModelAOResult.Select(x => new Error { Key = x.MemberNames.FirstOrDefault(), Message = x.ErrorMessage }));
                }
                else
                {
                    await func(aoResult);
                }
            }
            catch (DbUpdateException dbException)
            {
                aoResult.SetError(dbException.InnerException.Message, ex: dbException);
            }
            catch (Exception ex)
            {
                aoResult.SetError(ex.Message, ex: ex);
            }
            return aoResult;
        }

        #region -- Private helper --

        private List<ValidationResult> CheckRequest(object request)
        {
            request = request ?? new { };

            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(request, new ValidationContext(request), validationResultList, true);

            return SelectMany(validationResultList);
        }

        private List<ValidationResult> SelectMany(IEnumerable<ValidationResult> validationResultList)
        {
            var list = new List<ValidationResult>();

            list.AddRange(validationResultList.Select(x =>
            {
                if (x is CompositeValidationResult cvr)
                {
                    list.AddRange(SelectMany(cvr.Results));
                }
                return x;
            }));

            return list;
        }

        #endregion
    }
}
