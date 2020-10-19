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
/// Creates a Multiple AddressBook
/// </summary>
    public class MultipleAddressBook
    {
        /// <summary>
        /// The address book dictionary to accepts Multiple Address Book
        /// </summary>
        Dictionary<string, AddressBook> addressBookDictionary;
        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleAddressBook"/> class.
        /// Non Parameterised Constructor
        /// </summary>
        public MultipleAddressBook()
        {
            addressBookDictionary = new Dictionary<string, AddressBook>();
        }

        /// <summary>
        /// Adds the multiple address book using dictionary.
        /// </summary>      
        public void AddMultipleAddressBook(string name, AddressBook addressBook)
        {
            addressBookDictionary.Add(name, addressBook);
        }

        /// <summary>
        /// Displays the specified address book using the name given for AddressBook
        /// </summary>
        /// <param name="name">The name.</param>
        public void display(string name)
        {
            addressBookDictionary[name].DisplayContactPersonDetails();
        }       
          }

        }
    
