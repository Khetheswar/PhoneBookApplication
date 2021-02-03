using PBAEntitiesLayerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBADataAccessLayerLib;
using PBAExceptionLib;

namespace PBABusinessLayerLib
{
    public class PBABusinessLayer : IPBABusinessLayer
    {
        public void AddContact(Contact contact)
        {
            try
            {
                PBADataAccessLayer dal = new PBADataAccessLayer();
                dal.AddContact(contact);
            }
            catch(PBAException ex)
            {
                throw ex;
            }
        }

        public void AddContactCategory(ContactCategory cat)
        {
            try
            {
                PBADataAccessLayer dal = new PBADataAccessLayer();
                dal.AddContactCategory(cat);
            }
            catch(PBAException ex)
            {
                throw ex;
            }
        }

        public void DeleteContactById(int id)
        {
            try
            {
                PBADataAccessLayer dal = new PBADataAccessLayer();
                dal.DeleteContactById(id);
            }
            catch(PBAException ex)
            {
                throw ex;
            }
        }
        public void DeleteCategoryById(int id)
        {
            try
            {
                PBADataAccessLayer dal = new PBADataAccessLayer();
                dal.DeleteCategoryById(id);
            }
            catch (PBAException ex)
            {
                throw ex;
            }
        }

        public List<ContactCategory> GetAllcategoryNames()
        {
            try
            {
                PBADataAccessLayer dal = new PBADataAccessLayer();
                var lstcat = dal.GetAllcategoryNames();
                return lstcat;
            }
            catch(PBAException ex)
            {
                throw ex;
            }
        }

        public List<Contact> GetAllContactsById(int id)
        {
            try
            {
                PBADataAccessLayer dal = new PBADataAccessLayer();
                var lstcon = dal.GetAllContacstById(id);
                return lstcon;
            }
            catch(PBAException ex)
            {
                throw ex;
            }
        }

        public void UpdateContactById(Contact contact)
        {
            try
            {
                PBADataAccessLayer dal = new PBADataAccessLayer();
                dal.UpdateContactById(contact);
            }
            catch(PBAException ex)
            {
                throw ex;
            }
        }
        public void UpdateCategoryById(ContactCategory cat)
        {
            try
            {
                PBADataAccessLayer dal = new PBADataAccessLayer();
                dal.UpdateCategoryById(cat);
            }
            catch(PBAException ex)
            {
                throw ex;
            }
        }
    }
}
