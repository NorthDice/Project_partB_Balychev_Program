using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    DeleteItem();
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
            computerPeripheralAdd.QuantityInStock = int.Parse(Console.ReadLine());

            Console.WriteLine("Input price (more than 1000 and less then 0,99:");
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
            AlcoItemAdd.QuantityInStock = int.Parse(Console.ReadLine());

            Console.WriteLine("Input price (more than 5000 and less then 1,99:");
            AlcoItemAdd.Price = double.Parse(Console.ReadLine());

            Console.WriteLine("Input type of item ( Rum, Whiskey, Cognac, Bear, Vodka, )");
            AlcoItemAdd.Type = (AlcoholItems)Enum.Parse(typeof(AlcoholItems), Console.ReadLine());

            storeInventory.Add(AlcoItemAdd);

        }

        private void DeleteItem()
        {
            Console.WriteLine("Deleting item from the store: ");
            Console.WriteLine("Input company name:");

            ComputerPeripheralsStore computerPeripheralRemove = new ComputerPeripheralsStore();
            computerPeripheralRemove.CompanyName = Console.ReadLine();

            Console.WriteLine("Input count of items in stock: ");
            computerPeripheralRemove.QuantityInStock = int.Parse(Console.ReadLine());

            Console.WriteLine("Input price (more than and less then: ");
            computerPeripheralRemove.Price = double.Parse(Console.ReadLine());

            Console.WriteLine("Input type of item ( Headphones,Mouse,Keyboard,PowerBank");
            computerPeripheralRemove.Type = (PeripheriItems)Enum.Parse(typeof(PeripheriItems), Console.ReadLine());

            storeInventory.Remove(computerPeripheralRemove);
        }

        private void CheckAvailability()
        {
            Console.WriteLine("Checking availability of an item.");
            Console.WriteLine("Input company name:");

            ComputerPeripheralsStore isComputerPeripheralContains = new ComputerPeripheralsStore();
            isComputerPeripheralContains.CompanyName = Console.ReadLine();

            Console.WriteLine("Input count of items in stock: ");
            isComputerPeripheralContains.QuantityInStock = int.Parse(Console.ReadLine());

            Console.WriteLine("Input price (more than 0.99 and less then 1000:");
            isComputerPeripheralContains.Price = double.Parse(Console.ReadLine());

            Console.WriteLine("Input type of item ( Headphones,Mouse,Keyboard,PowerBank");
            isComputerPeripheralContains.Type = (PeripheriItems)Enum.Parse(typeof(PeripheriItems), Console.ReadLine());

            storeInventory.Contains(isComputerPeripheralContains);
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
