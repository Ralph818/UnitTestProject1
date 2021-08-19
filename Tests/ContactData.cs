using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.Tests
{
    class ContactData
    {
        private string subject;
        private string email;
        private string orderReference;
        private string message;
        private string filePath;

        //Properties
        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string OrderReference
        {
            get
            {
                return orderReference;
            }
            set
            {
                orderReference = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                filePath = value;
            }
        }
        //Constructor
        public ContactData(string subject, string email, string orderReference, string filePath, string message)
        {
            Subject = subject;
            Email = email;
            OrderReference = orderReference;
            Message = message;
            FilePath = filePath;
        }
    }
}
