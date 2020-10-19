// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Kretika Arora"/>
//
///// Including the requried assemblies in to the programusing System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AddressBookSystem
{
    /// <summary>
    /// Creates an Addressbook 
    ///Performs Operations like adding, displaying , updating , deleting details using a list 
    /// </summary>
    public class AddressBook
    {
        /// <summary>
        /// The address book list for storing details
        /// </summary>
        private List<ContactPerson> addressBookList; 
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBook"/> class.
        /// Non Parameterised Constructor for AddressBook
        /// </summary>
        public AddressBook()
        {
            addressBookList = new List<ContactPerson>();           
        }

        /// <summary>
        /// Adds the details of persons.
        /// </summary>     
        public void AddDetailsOfPersons(string firstName, string lastName, string address, string city, string state, int zip, double phoneNo, string eMail)
        {
            /// Creates an instance of class Contact Person 
            /// For Adding the details in the list addressbooklist
            ContactPerson contactPerson = new ContactPerson(firstName, lastName, address, city, state, zip, phoneNo, eMail);
            foreach (ContactPerson person in addressBookList)
            {
                if (person.firstName.Equals(firstName) && person.lastName.Equals(lastName))
                {
                    Console.WriteLine("Person with this full name already exists in the contact book");
                    return;
                }
         }
            addressBookList.Add(contactPerson);
            Console.WriteLine("detail succesfully added");
            if(Program.dictionaryByState.ContainsKey(contactPerson.state))
            {
                Program.dictionaryByState[contactPerson.state].Add(contactPerson);
            }
            else
            {
                List<ContactPerson> list = new List<ContactPerson>();
                list.Add(contactPerson);
                Program.dictionaryByState.Add(contactPerson.state, list);
            }
            if (Program.dictionaryByCity.ContainsKey(contactPerson.city))
            {
                Program.dictionaryByCity[contactPerson.city].Add(contactPerson);
            }
            else
            {
                List<ContactPerson> list = new List<ContactPerson>();
                list.Add(contactPerson);
                Program.dictionaryByCity.Add(contactPerson.city, list);
            }


        }

        /// <summary>
        /// Displays the contact person details.
        /// </summary>
        public void DisplayContactPersonDetails()
        {
            /// numberOfPersons declared to get number of contacts in a list 
            int numberOfPersons = 1;
            /// using foreach statement to print the details of contact 
            foreach (ContactPerson contactPerson in addressBookList)
            {
                Console.WriteLine("The Details of Contact Number {0} -", numberOfPersons);
                Console.WriteLine("firstName : " + contactPerson.firstName + "  last name  :" + contactPerson.lastName + " address : " + contactPerson.address + " city : " + contactPerson.city + " state : " + contactPerson.state + "  zip : " + contactPerson.zip + " phone number : " + contactPerson.phoneNo + "  email :" + contactPerson.email);
                numberOfPersons++;              
            }
        }

        /// <summary>
        /// Updates the contact person details.      
        /// </summary>
        public void UpdateContactPersonDetails(string newFirstName, string newLastName)
        {
            foreach (ContactPerson contactPerson in addressBookList)
            {
                ///checking if the  full name  in the list matches with the full name entered by the user 
                if (newFirstName == contactPerson.firstName && newLastName == contactPerson.lastName)
                {
                    Console.WriteLine("Enter the details to be updated");
                    contactPerson.address = Console.ReadLine();
                    contactPerson.city = Console.ReadLine();
                    contactPerson.state = Console.ReadLine();
                    contactPerson.zip = Convert.ToInt32(Console.ReadLine());
                    contactPerson.phoneNo = Convert.ToDouble(Console.ReadLine());
                    contactPerson.email = Console.ReadLine();
                    Console.WriteLine("details has been updated");
                    Console.WriteLine("the updated list is-");
                    DisplayContactPersonDetails();
                }
            }
        }

        /// <summary>
        /// Deletes the contact person details.
        /// </summary>     
        public void DeleteContactPersonDetails(string fName, string lName)
        {
            foreach (ContactPerson contactPerson in addressBookList)
            {
                if (fName == contactPerson.firstName && lName == contactPerson.lastName)
                {
                    addressBookList.Remove(contactPerson);
                    Console.WriteLine("contact person deleted");
                    Console.WriteLine("updated list is ");
                    DisplayContactPersonDetails();
                }
            }
        }
        public void SearchingByState()
        {
            int index = 0;
            Console.WriteLine("enter the name of state you wish to search");
            string searchState = Console.ReadLine();
            if (!Program.dictionaryByState.ContainsKey(searchState))
            {
                Console.WriteLine("no such state records found");
                return;
            }
            foreach (ContactPerson contactPerson in Program.dictionaryByState[searchState])
            {
                index++;
                Console.WriteLine("firstName : " + contactPerson.firstName + "  last name  :" + contactPerson.lastName + " address : " + contactPerson.address + " city : " + contactPerson.city + " state : " + contactPerson.state + "  zip : " + contactPerson.zip + " phone number : " + contactPerson.phoneNo + "  email :" + contactPerson.email);
            }
            Console.WriteLine("The count of {0} is {1}", searchState, index);

        }
        public void SearchingByCity()
        {
            int index = 0;
            Console.WriteLine("enter the name of city you wish to search");
            string searchCity = Console.ReadLine();
            if (!Program.dictionaryByCity.ContainsKey(searchCity))
            {
                Console.WriteLine("no such city records found");
                return;
            }
            foreach(ContactPerson contactPerson in Program.dictionaryByCity[searchCity])
            {
                index++;
                Console.WriteLine("firstName : " + contactPerson.firstName + "  last name  :" + contactPerson.lastName + " address : " + contactPerson.address + " city : " + contactPerson.city + " state : " + contactPerson.state + "  zip : " + contactPerson.zip + " phone number : " + contactPerson.phoneNo + "  email :" + contactPerson.email);
            }
            Console.WriteLine("The count of {0} is {1}",searchCity,index);

        }
       
    }
}

 




