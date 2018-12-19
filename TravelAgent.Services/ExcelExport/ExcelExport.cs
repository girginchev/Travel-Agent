namespace TravelAgent.Services.ExcelExport
{
    using Microsoft.AspNetCore.Hosting;
    using OfficeOpenXml;
    using OfficeOpenXml.Table;
    using System.Collections.Generic;
    using TravelAgent.Services.Reservations.Models;

    public class ExcelExport : IExcelExport
    {
        private const string XlsxContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        private readonly IHostingEnvironment _hostingEnvironment;


        public ExcelExport(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }

        public ExcelPackage CreateExcelPackage(List<ReservationsDetailsServiceModel> reservations)
        {
            var package = new ExcelPackage();
            package.Workbook.Properties.Title = $"{reservations[0].TourTitle} {reservations[0].TripStartDate.ToShortDateString()}";
            package.Workbook.Properties.Author = "Travel Agent";
            package.Workbook.Properties.Subject = $"{reservations[0].TourTitle} {reservations[0].TripStartDate.ToShortDateString()}";
            package.Workbook.Properties.Keywords = "Reservations";


            var worksheet = package.Workbook.Worksheets.Add($"{reservations[0].TourTitle} {reservations[0].TripStartDate.ToShortDateString()}");
            
            worksheet.Cells[1, 1].Value = "Seat N:";
            worksheet.Cells[1, 2].Value = "Finalized";
            worksheet.Cells[1, 3].Value = "First Name";
            worksheet.Cells[1, 4].Value = "Surname";
            worksheet.Cells[1, 5].Value = "Last Name";
            worksheet.Cells[1, 6].Value = "EGN";
            worksheet.Cells[1, 7].Value = "Id card";
            worksheet.Cells[1, 8].Value = "Date of issue";
            worksheet.Cells[1, 9].Value = "Validity date";
            worksheet.Cells[1, 10].Value = "Passport";
            worksheet.Cells[1, 11].Value = "Passport Date of issue";
            worksheet.Cells[1, 12].Value = "Passport Validity date";
            worksheet.Cells[1, 13].Value = "Email";
            worksheet.Cells[1, 14].Value = "Phone";

            //Add values

            var numberformat = "#,##0";
            var dataCellStyleName = "TableNumber";
            var numStyle = package.Workbook.Styles.CreateNamedStyle(dataCellStyleName);
            numStyle.Style.Numberformat.Format = numberformat;

            var cnt = 2;
            foreach (var res in reservations)
            {
                worksheet.Cells[cnt, 1].Value = res.SeatNumber;
                worksheet.Cells[cnt, 2].Value = res.IsFinalized;
                worksheet.Cells[cnt, 3].Value = res.FirstNameLatin;
                worksheet.Cells[cnt, 4].Value = res.SurNameLatin;
                worksheet.Cells[cnt, 5].Value = res.LastNameLatin;
                worksheet.Cells[cnt, 6].Value = res.EGN;
                worksheet.Cells[cnt, 7].Value = res.IdCard;
                worksheet.Cells[cnt, 8].Value = res.IdCardDateOfIssue.ToShortDateString();
                worksheet.Cells[cnt, 9].Value = res.IdCardValidityDate.ToShortDateString();
                worksheet.Cells[cnt, 10].Value = res.PasportNumber;
                worksheet.Cells[cnt, 11].Value = res.PasportDateOfIssue.ToShortDateString();
                worksheet.Cells[cnt, 12].Value = res.PasportValidityDate.ToShortDateString();
                worksheet.Cells[cnt, 13].Value = res.Email;
                worksheet.Cells[cnt, 14].Value = res.Phone;
                cnt++;
            }
            worksheet.Cells[cnt, 1].Value = reservations[0].TourTitle;
            worksheet.Cells[cnt, 2].Value = reservations[0].TripStartDate.ToShortDateString();
            
            var tbl = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 1, fromCol: 1, toRow: reservations.Count + 2, toColumn: 14), "Data");
            tbl.ShowHeader = true;
            tbl.TableStyle = TableStyles.Dark9;
            
            worksheet.Cells[1, 1, reservations.Count + 2, 14].AutoFitColumns();

            return package;
        }
    }
}
