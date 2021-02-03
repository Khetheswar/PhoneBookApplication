using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using PhoneBookApplication.Models;
using Newtonsoft.Json;

namespace PhoneBookApplication.Controllers
{
    public class PBAController : Controller
    {
        // GET: PBA
        public ActionResult ContactCategories()
        {
            //calling Api Get for displaying records
            Uri uri = new Uri("http://localhost:52862/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("PBA").Result;
                var catlist = JsonConvert.DeserializeObject<List<ContactCategory>>(result);

                return View(catlist);
            }
        }
        public ActionResult ContactDetails(int id)
        {
            //calling Api Get for displaying contact details based on Categoryid
            Uri uri = new Uri("http://localhost:52862/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("PBA/"+id).Result;
                var contactlist = JsonConvert.DeserializeObject<List<Contact>>(result);
 
                return View(contactlist);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ContactCategory cat)
        {
            //calling API POST for Insert Categoryrecord
            Uri uri = new Uri("http://localhost:52862/api/");
            using(var client=new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.PostAsJsonAsync("PBA", cat).Result;
                if (result.IsSuccessStatusCode == true)
                {
                    ViewData.Add("msg", "Record inserted succesfully");
                    return RedirectToAction("ContactDetails");
                }
                else
                {
                    ViewData.Add("msg", "Could not insert record,Some error Occured");
                }
                return View();
            }
        }
        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateContact(Contact contact)
        {
            //calling API POST for Insert Contactrecord
            Uri uri = new Uri("http://localhost:52862/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.PostAsJsonAsync("PBA/AddContact", contact).Result;
                if (result.IsSuccessStatusCode == true)
                {
                    ViewData.Add("msg", "Record inserted Sucessfully...");
                    return RedirectToAction("ContactDetails",new { id=contact.CategoryId});
                }
                else
                {
                    ViewData.Add("msg", "Could not insert record,Some error Happened");
                }
                return View("CreateContact");
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            //calling API Delete for DELETE
            Uri uri = new Uri("http://localhost:52862/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.DeleteAsync("PBA/"+id).Result;
                if (result.IsSuccessStatusCode == true)
                {
                    TempData.Add("msg", "Record deleted Sucessfully");
                }
                else
                {
                    TempData.Add("msg", "Could not delete record due to some error");
                }
                return RedirectToAction("ContactCategories");
            }
        }
        [HttpGet]
        public ActionResult DeleteContact(int id)
        {
            //calling API Delete for deleting the Cotactrecord
            Uri uri = new Uri("http://localhost:52862/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.DeleteAsync("PBA/DeleteContact/"+ id).Result;
                return RedirectToAction("ContactDetails");
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //calling the api PUT for updating the category record
            Uri uri = new Uri("http://localhost:52862/api/");
            using(var client=new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("PBA/"+id).Result;
                var cat = JsonConvert.DeserializeObject<ContactCategory>(result);
                return View(cat);
            }
        }
        [HttpPost]
        public ActionResult Edit(ContactCategory cat)
        {
            Uri uri = new Uri("http://localhost:52862/api/");
            using(var client=new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.PutAsJsonAsync("PBA/"+cat.CategoryId,cat).Result;
                return RedirectToAction("ContactCategories");
            }
        }
        [HttpGet]
        public ActionResult EditContact(int id)
        {
            //calling api for PUT of updating the contact record
            Uri uri = new Uri("http://localhost:52862/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.GetStringAsync("PBA/" + id).Result;
                var contact = JsonConvert.DeserializeObject<Contact>(result);
                return View(contact);
            }
        }
        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            Uri uri = new Uri("http://localhost:52862/api/");
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                var result = client.PutAsJsonAsync("PBA/"+contact.ContactId,contact).Result;
                return RedirectToAction("ContactDetails");
            }
        }
    }
}