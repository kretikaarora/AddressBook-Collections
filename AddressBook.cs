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
        public List<ContactPerson> contactByStateList;
        public Dictionary<string, List<ContactPerson>> dictionaryByState;
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBook"/> class.
        /// Non Parameterised Constructor for AddressBook
        /// </summary>
        public AddressBook()
        {
            addressBookList = new List<ContactPerson>();
            contactByStateList = new List<ContactPerson>();
            dictionaryByState = new Dictionary<string, List<ContactPerson>>();
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
        public void SearchingByState(string searchState)
        {           
            foreach (ContactPerson contactPerson in addressBookList)
            {
                if (contactPerson.state.Equals(searchState))
                {
                    Console.WriteLine(contactPerson.firstName+" "+contactPerson.lastName);                 
                }              
            }
        }
        public void SearchingByCity(string searchCity)
        {
            foreach (ContactPerson contactPerson in addressBookList)
            {
                if (contactPerson.city.Equals(searchCity))
                {
                    Console.WriteLine(contactPerson.firstName + " " + contactPerson.lastName);
                }               
            }
        }
        public void ContactDetailsByState(string ContactsCitywise)
        { 
            foreach(ContactPerson contactPerson in addressBookList)
            {
                if(contactPerson.city==ContactsCitywise)
                {
                    contactByStateList.Add(contactPerson);
                }
            }
          foreach(ContactPerson contact in contactByStateList)
            {
                Console.WriteLine("firstName : " + contact.firstName + "  last name  :" + contact.lastName + " address : " + contact.address + " city : " + contact.city + " state : " + contact.state + "  zip : " + contact.zip + " phone number : " + contact.phoneNo + "  email :" + contact.email);
            }
        }
            
        }
    }

 




