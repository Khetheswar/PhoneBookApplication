using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBAEntitiesLayerLib;

namespace PBADataAccessLayerLib
{
    public interface IPBADataAccess
    {
        List<ContactCategory> GetAllcategoryNames();
        void AddContactCategory(ContactCategory cat);
        List<Contact> GetAllContacstById(int id);
        void AddContact(Contact contact);
        void DeleteContactById(int id);
        void DeleteCategoryById(int id);
        void UpdateContactById(Contact contact);
        void UpdateCategoryById(ContactCategory cat);
    }
}
