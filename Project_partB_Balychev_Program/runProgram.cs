using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Project_partB_Balychev_Program
{
    internal class runProgram
    {
        private StoreInventory storeInventory;

        public runProgram()
        {
            storeInventory = new StoreInventory();
        }

        public void Run() 
        {

            int mode = int.MaxValue;

            while(true)
            {
                Menu.Options();

                mode = Reader.ReadInt32(0,6);

                switchMenu(mode);
            }
            
        }
        private void switchMenu(int mode)
        {
            switch (mode)
            {
                case 1:
                    ChooseAdd();
                    break;
                case 2:
                   ChooseDelete();
                    break;
                case 3:
                    CheckAvailability();
                    break;
                case 4:
                    SortByPrice();
                    break;
                case 5:
                    StoreClear();
                    break;
                case 6:
                    Information();
                    break;
                case 0: Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Unknown operation!");
                    break;
            }
        }

        private void ChooseAdd()
        {
            Menu.ChooseAdd();

            int option = Reader.ReadInt32(1, 2);

            SwitchAdd(option);
        }

        private void ChooseDelete() 
        { 
            Menu.ChooseRemove();

            int option = Reader.ReadInt32(1, 2);

            SwitchDelete(option);
        }

        private void SwitchDelete(int option)
        {
            switch(option)
            {
                case 1:
                    DeletePeripheryItem();
                    break;

                case 2:
                    DeleteAlcoholItem();
                    break;

            }
        }
        private void SwitchAdd(int option) 
        {
            switch(option)
            {
                case 1:
                    AddComputerItem();
                    break;
                case 2:
                    AddAlcoItem();
                    break;
                case 3:
                    break;
                default: 
                    Console.WriteLine("Unknown Operation!");
                    break;
            }

        }
        private void AddComputerItem()
        {
            Console.WriteLine("Adding computer item to the store:");
            Console.WriteLine("Input company name:");

            ComputerPeripheralsStore computerPeripheralAdd = new ComputerPeripheralsStore();
            computerPeripheralAdd.CompanyName = Console.ReadLine();

            Console.WriteLine("Input count of items in stock: ");
            computerPeripheralAdd.QuantityInStock = Reader.ReadInt32();

            Console.WriteLine("Input price (more than 0,99 and less then 1000):");
            computerPeripheralAdd.Price = double.Parse(Console.ReadLine());

            Console.WriteLine("Input type of item ( Headphones,Mouse,Keyboard,PowerBank )");
            computerPeripheralAdd.Type = (PeripheriItems)Enum.Parse(typeof(PeripheriItems), Console.ReadLine());

            storeInventory.Add(computerPeripheralAdd);
        }

        private void AddAlcoItem()
        {
            Console.WriteLine("Adding alco item to the store:");
            Console.WriteLine("Input company name:");

            AlcoholStore AlcoItemAdd = new AlcoholStore();
            AlcoItemAdd.AlcoCompanyName = Console.ReadLine();

            Console.WriteLine("Input count of items in stock: ");
            AlcoItemAdd.QuantityInStock = Reader.ReadInt32();

            Console.WriteLine("Input price (more than 1,99 and less then 5000 ):");
            AlcoItemAdd.Price = double.Parse(Console.ReadLine());

            Console.WriteLine("Input type of item ( Rum, Whiskey, Cognac, Bear, Vodka, )");
            AlcoItemAdd.Type = (AlcoholItems)Enum.Parse(typeof(AlcoholItems), Console.ReadLine());

            storeInventory.Add(AlcoItemAdd);

        }

        private void DeletePeripheryItem()
        {
            Console.WriteLine("Deleting item from the store: ");
            Console.WriteLine("Input company name:");

            string companyName = Console.ReadLine();

            Console.WriteLine("Input count of items in stock: ");
            int quantityInStock = Reader.ReadInt32();

            Console.WriteLine("Input price (more than and less than: ");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("Input type of item ( Headphones,Mouse,Keyboard,PowerBank )");
            PeripheriItems itemType = (PeripheriItems)Enum.Parse(typeof(PeripheriItems), Console.ReadLine());

            // Створюємо об'єкт для пошуку
            ComputerPeripheralsStore itemToDelete = new ComputerPeripheralsStore()
            {
                CompanyName = companyName,
                QuantityInStock = quantityInStock,
                Price = price,
                Type = itemType
            };

            bool removed = storeInventory.Remove(itemToDelete);

            if (removed)
            {
                Console.WriteLine("Item removed successfully.");
            }
            else
            {
                Console.WriteLine("Item not found in the inventory.");
            }
        }
        private void DeleteAlcoholItem()
        {
            Console.WriteLine("Deleting alcohol item from the store:");
            Console.WriteLine("Input company name:");

            string companyName = Console.ReadLine();

            Console.WriteLine("Input count of items in stock: ");
            int quantityInStock = Reader.ReadInt32();

            Console.WriteLine("Input price (more than 1.99 and less than 5000):");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("Input type of item ( Rum, Whiskey, Cognac, Bear, Vodka):");
            AlcoholItems type = (AlcoholItems)Enum.Parse(typeof(AlcoholItems), Console.ReadLine());

            AlcoholStore alcoholItemRemove = new AlcoholStore(companyName, quantityInStock, price, type);
            storeInventory.Remove(alcoholItemRemove);
        }

        private void CheckAvailability()
        {
            Console.WriteLine("Checking availability of an item.");
            Console.WriteLine("Input company name:");

            ComputerPeripheralsStore isComputerPeripheralContains = new ComputerPeripheralsStore();
            isComputerPeripheralContains.CompanyName = Console.ReadLine();

            Console.WriteLine("Input count of items in stock: ");
            isComputerPeripheralContains.QuantityInStock = Reader.ReadInt32();

            Console.WriteLine("Input price (more than 0.99 and less then 1000):");
            isComputerPeripheralContains.Price = double.Parse(Console.ReadLine());

            Console.WriteLine("Input type of item ( Headphones,Mouse,Keyboard,PowerBank )");
            isComputerPeripheralContains.Type = (PeripheriItems)Enum.Parse(typeof(PeripheriItems), Console.ReadLine());

            storeInventory.Contains(isComputerPeripheralContains);
            Console.WriteLine(isComputerPeripheralContains.ToString()); 
        }

        private void SortByPrice()
        {
            Console.WriteLine("Sorting items by price.");

            storeInventory.SortByPrice();
        }

        private void StoreClear()
        {
            Console.WriteLine("Clearing the store inventory.");

            storeInventory.Clear();

            Console.WriteLine("Store inventory cleared.");
        }

        private void Information()
        {
            Console.WriteLine("Displaying information about items in the store.");

            string Info = storeInventory.GetStorageInfo();

            Console.WriteLine(Info);
        }

    }
}
