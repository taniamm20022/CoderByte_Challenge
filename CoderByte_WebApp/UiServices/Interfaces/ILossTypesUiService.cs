using CoderByte_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoderByte_WebApp.UiServices.Interfaces
{
    public interface ILossTypesUiService
    {
        Task<LossTypesIndexViewModel> GetIndexViewModel();
    }
}
