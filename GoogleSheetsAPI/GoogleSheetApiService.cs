using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;

namespace GoogleSheetsAPI
{
//    public class GoogleSheetApiService
//    {
//        const string SPREADSHEET_ID = "143JhAuG7l_tSk5WMR4A1t1YuC-jL3r-DLmzw_WvC_bk";
//        const string SHEET_NAME = "Items";

//        SpreadsheetsResource.ValuesResource _googleSheetValues;

      
//        public GoogleSheetApiService(GoogleSheetsHelper googleSheetsHelper)
//        {
//            _googleSheetValues = googleSheetsHelper.Service.Spreadsheets.Values;
//            //_apiService = apiService;
//        }

//        public List<Item> ActualizarGoogleSheetYAPI()
//        {
//            const string SPREADSHEET_ID = "143JhAuG7l_tSk5WMR4A1t1YuC-jL3r-DLmzw_WvC_bk";
//            const string SHEET_NAME = "Items";
//            var range = $"{SHEET_NAME}!A:D";

//            var request = _googleSheetValues.Get(SPREADSHEET_ID, range);
//            var response = request.Execute();
//            var values = response.Values;

//            var items = ItemsMapper.MapFromRangeData(values);
//            return items;


//            //_apiService.ActualizarItems(items);
//        }
//    }
}
