// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
//
/// Including the requried assemblies in to the program
using System;
using System.Collections.Generic;

namespace AddressBookSystem
{/// <summary>
/// Entry Point of the program 
/// </summary>
    class Program
    {
       
        public static Dictionary<string, List<ContactPerson>> dictionaryByState = new Dictionary<string, List<ContactPerson>>();
        public static Dictionary<string, List<ContactPerson>> dictionaryByCity = new Dictionary<string, List<ContactPerson>>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Multiple Address Book ");
            /// creating instance of Multiple Address Book
            MultipleAddressBook multipleAddressBook = new MultipleAddressBook();
            AddressBook addressBook1 = new AddressBook();

            //Accepting details for name of addressbook and contact details in addressBook
            //While loop will break if the user enters empty string 
            while (true)
            {
                Console.WriteLine("enter the name of Addressbook");
                string name = Console.ReadLine();
                if (name == "") break;//while loop will break when the if statement is true 
                AddressBook addressBook = new AddressBook();
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Please enter your firstname");
                    string firstName = Console.ReadLine();
                    if (firstName == "")
                    {                      
                        break;
                        //while loop will break when the if statement is true 
                    }
                    Console.WriteLine("Please enter your lastname");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Please enter your Address");
                    string address = Console.ReadLine();
                    Console.WriteLine("Please enter your city");
                    string city = Console.ReadLine();
                    Console.WriteLine("Please enter your state");
                    string state = Console.ReadLine();
                    Console.WriteLine("Please enter your zip");
                    int zip = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter your phone no");
                    double phoneNo = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Please enter your email");
                    string email = Console.ReadLine();
                    addressBook.AddDetailsOfPersons(firstName, lastName, address, city, state, zip, phoneNo, email);                  
                }
                /// calling function to display contact details
                
                addressBook.DisplayContactPersonDetails();            
                Console.WriteLine("To update Details enter 'Y' else enter 'N' ");
                char updateCheck = Convert.ToChar(Console.ReadLine());
                /// to call the update function in AddressBook if Y is entered              
                    if (updateCheck == 'Y')
                {
                    Console.WriteLine("enter the first name & last name of the person to be updated");
                    string newFirstName = Console.ReadLine();
                    string newLastName = Console.ReadLine();
                    addressBook.UpdateContactPersonDetails(newFirstName, newLastName);
                }
                Console.WriteLine("To delete Details enter 'Y' else enter 'N' ");
                char deleteCheck = Convert.ToChar(Console.ReadLine());
                /// to call the delete function in AddressBook if Y is entered.
                if (deleteCheck == 'Y')
                {
                    Console.WriteLine("enter the first name & last name of the person contact to be delete  ");
                    string fName = Console.ReadLine();
                    string lName = Console.ReadLine();
                    addressBook.DeleteContactPersonDetails(fName, lName);
                }
                /// adding details in multiple address book using name enter and AddressBook instance created             
                multipleAddressBook.AddMultipleAddressBook(name, addressBook);
            }
            /// display multiple AddressBook using name of addressbook
            Console.WriteLine("To display the contacts of addressbook press Y else N");
            char addressBookCheck = Convert.ToChar(Console.ReadLine());
            if(addressBookCheck=='Y')
            {
                multipleAddressBook.display();
            }          
            Console.WriteLine("Press Y to search by state");
            char stateSearchCheck = Convert.ToChar(Console.ReadLine());
            if(stateSearchCheck=='Y')
            {
                addressBook1.SearchingByState();
            }
            Console.WriteLine("Press Y to get contacts by city");
            char cityCheck = Convert.ToChar(Console.ReadLine());
            if (cityCheck == 'Y')
            {
                addressBook1.SearchingByCity();
            }
        }
    }
}
