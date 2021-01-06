using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HX.Rider.Extensions
{
    public static class ModelStateExtensions
    {
        public static string GetStateError(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                foreach (var key in modelState.Keys)
                {
                    var state = modelState[key];
                    if (state.Errors.Any())
                    {
                        return state.Errors.FirstOrDefault().ErrorMessage;
                    }
                }
            }
            return string.Empty;
        }
    }
}
