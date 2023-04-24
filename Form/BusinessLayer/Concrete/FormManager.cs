using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FormManager : IFormService
    {
        IFormDal _formDal;

        public FormManager(IFormDal formDal)
        {
            _formDal = formDal;
        }

        public void Add(Form t)
        {
            _formDal.Insert(t);
        }

        public void Delete(Form t)
        {
            _formDal.Delete(t);
        }

        public Form GetById(int id)
        {
            return _formDal.GetByID(id);
        }

        public List<Form> GetList()
        {
            return _formDal.GetListAll();
        }

        public void Update(Form t)
        {
            _formDal.Update(t);
        }
    }
}
