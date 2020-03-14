using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WarehouseConsole
{

    public class Warehouse
    {
        public string warehouseId { get; set; }
        public string location { get; set; }
    }

    public class Inventory
    {
        public string sku { get; set; }
        public string description { get; set; }
        public string warehouseId { get; set; }
    }

    
    class Program
    {

        static HttpClient client = new HttpClient();

        static async Task<Warehouse> GetWarehouseAsync(string path)
        {
            Warehouse warehouse = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                warehouse = await response.Content.ReadAsAsync<Warehouse>();
            }
            return warehouse;
        }

        static async Task<Inventory> GetInventoryAsync(string path)
        {
            Inventory inventory = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                inventory = await response.Content.ReadAsAsync<Inventory>();
            }
            return inventory;
        }

        static void ShowWarehouse(Warehouse warehouse)
        {
            Console.WriteLine($"Warehouse identifier: {warehouse.warehouseId}\tWarehouse Location: {warehouse.location}");
        }

        static void ShowInventory(Inventory inventory)
        {
            Console.WriteLine($"Warehouse Id: {inventory.warehouseId}\tSKU: {inventory.sku}\tDescription: {inventory.description}");
        }
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            Console.WriteLine("Acme Corporation Warehouse Inventory");
            Console.WriteLine("====================================");
            //Invoke Warehouse Service to get Warehouse
            /*Warehouse warehouse = new Warehouse();
            warehouse.warehouseId = "2";
            warehouse.location = "New Bedford, MA, USA";*/
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:8080");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                Warehouse warehouse = await GetWarehouseAsync("/warehouse/2");
                ShowWarehouse(warehouse);
            }catch(Exception e) { Console.WriteLine(e.Message); }
            //Invoke Catalog Service to get Inventory
            /*Inventory inventory = new Inventory();
            inventory.warehouseId = "2";
            inventory.sku = "445-121441-ET";
            inventory.description = "Expansion Tank";*/
            client.BaseAddress = new Uri("http://localhost:5000");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                Inventory inventory = await GetInventoryAsync("/catalog");
                ShowInventory(inventory);
            }catch(Exception e) { Console.WriteLine(e.Message); }
        
        }
    }
}
