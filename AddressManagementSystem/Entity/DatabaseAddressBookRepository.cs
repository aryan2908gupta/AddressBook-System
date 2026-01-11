using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;


namespace AddressManagementSystem.Entity
{
    public class DatabaseAddressBookRepository : IAddressBookRepository
    {
        string constr = "Data Source=HP;Initial Catalog=aryan;Integrated Security=True; Encrypt = False";

        public async Task SaveAsync(List<Contact> contacts)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                await con.OpenAsync();
                foreach (var c in contacts)
                {
                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO Contacts 
                  (FirstName, LastName, Address, City, State, ZipCode, PhoneNumber, Email)
                  VALUES (@fn,@ln,@ad,@ci,@st,@zip,@ph,@em)", con);

                    cmd.Parameters.AddWithValue("@fn", c.FirstName);
                    cmd.Parameters.AddWithValue("@ln", c.LastName);
                    cmd.Parameters.AddWithValue("@ad", c.Address);
                    cmd.Parameters.AddWithValue("@ci", c.City);
                    cmd.Parameters.AddWithValue("@st", c.State);
                    cmd.Parameters.AddWithValue("@zip", c.ZipCode);
                    cmd.Parameters.AddWithValue("@ph", c.PhoneNumber);
                    cmd.Parameters.AddWithValue("@em", c.Email);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
            public async Task<List<Contact>> LoadAsync()
        {
            List<Contact> contacts = new List<Contact>();

            using SqlConnection con = new SqlConnection(constr);
            await con.OpenAsync();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Contacts", con);
            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                contacts.Add(new Contact
                {
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    Address = reader["Address"].ToString(),
                    City = reader["City"].ToString(),
                    State = reader["State"].ToString(),
                    ZipCode = reader["ZipCode"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    Email = reader["Email"].ToString()
                });
            }

            return contacts;
        }
    }
    }

