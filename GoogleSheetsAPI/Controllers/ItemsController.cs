﻿using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using static Google.Apis.Sheets.v4.SpreadsheetsResource.ValuesResource;

namespace GoogleSheetsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        const string SPREADSHEET_ID = "1zDXklo0tcJ4KDMRn9mgLHF3rfaIJ0hAMEMtoPgM98p8";
        const string SHEET_NAME = "PDV";

        SpreadsheetsResource.ValuesResource _googleSheetValues;

        public ItemsController(GoogleSheetsHelper googleSheetsHelper)
        {
            _googleSheetValues = googleSheetsHelper.Service.Spreadsheets.Values;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var range = $"{SHEET_NAME}!A:F";

            var request = _googleSheetValues.Get(SPREADSHEET_ID, range);
            var response = request.Execute();
            var values = response.Values;

            return Ok(ItemsMapper.MapFromRangeData(values));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocurrió un error: {ex.Message}");

            }
        }

        //[HttpGet("{rowId}")]
        //public IActionResult Get(int rowId)
        //{
        //    var range = $"{SHEET_NAME}!A{rowId}:D{rowId}";
        //    var request = _googleSheetValues.Get(SPREADSHEET_ID, range);
        //    var response = request.Execute();
        //    var values = response.Values;

        //    return Ok(ItemsMapper.MapFromRangeData(values).FirstOrDefault());
        //}

        //[HttpPost]
        //public IActionResult Post(Item item)
        //{
        //    var range = $"{SHEET_NAME}!A:D";
        //    var valueRange = new ValueRange
        //    {
        //        Values = ItemsMapper.MapToRangeData(item)
        //    };

        //    var appendRequest = _googleSheetValues.Append(valueRange, SPREADSHEET_ID, range);
        //    appendRequest.ValueInputOption = AppendRequest.ValueInputOptionEnum.USERENTERED;
        //    appendRequest.Execute();

        //    return CreatedAtAction(nameof(Get), item);
        //}

        //[HttpPut("{rowId}")]
        //public IActionResult Put(int rowId, Item item)
        //{
        //    var range = $"{SHEET_NAME}!A{rowId}:D{rowId}";
        //    var valueRange = new ValueRange
        //    {
        //        Values = ItemsMapper.MapToRangeData(item)
        //    };

        //    var updateRequest = _googleSheetValues.Update(valueRange, SPREADSHEET_ID, range);
        //    updateRequest.ValueInputOption = UpdateRequest.ValueInputOptionEnum.USERENTERED;
        //    updateRequest.Execute();

        //    return NoContent();
        //}

        //[HttpDelete("{rowId}")]
        //public IActionResult Delete(int rowId)
        //{
        //    var range = $"{SHEET_NAME}!A{rowId}:D{rowId}";
        //    var requestBody = new ClearValuesRequest();

        //    var deleteRequest = _googleSheetValues.Clear(requestBody, SPREADSHEET_ID, range);
        //    deleteRequest.Execute();

        //    return NoContent();
        //}
    }
}
