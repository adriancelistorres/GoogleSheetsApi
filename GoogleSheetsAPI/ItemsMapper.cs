using System;
using System.Collections.Generic;

namespace GoogleSheetsAPI
{
    public static class ItemsMapper
    {
        public static List<Item> MapFromRangeData(IList<IList<object>> values)
        {
            var items = new List<Item>();
            if (values != null && values.Count > 0)
            {
                foreach (var value in values)
            {
                    try
                    {
                        var item = new Item
                        {
                            JEFEDEVENTA = value.Count > 0 ? value[0].ToString() : null,
                            SUPERVISOR = value.Count > 1 ? value[1].ToString() : null,
                            PDV = value.Count > 2 ? value[2].ToString() : null,
                            Fecha = value.Count > 3 ? value[3].ToString() : null,
                            HoraApertura = value.Count > 4 ? value[4].ToString() : null,
                            HoraCierre = value.Count > 5 ? value[5].ToString() : null,
                        };

                        items.Add(item);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al mapear los valores: {ex.Message}");
                        // Otras acciones de manejo del error, si es necesario
                    }


                }
            }

            return items;
        }

        public static IList<IList<object>> MapToRangeData(Item item)
        {
            var objectList = new List<object>() { item.JEFEDEVENTA, item.SUPERVISOR, item.PDV, item.Fecha, item.HoraApertura,item.HoraCierre };
            var rangeData = new List<IList<object>> { objectList };
            return rangeData;
        }
    }
}
