namespace TravelAgent.Services.ExcelExport
{
    using OfficeOpenXml;
    using System.Collections.Generic;
    using TravelAgent.Services.Reservations.Models;

    public interface IExcelExport
    {
        ExcelPackage CreateExcelPackage(List<ReservationsDetailsServiceModel> reservations);
    }
}
