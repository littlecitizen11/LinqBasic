using System;
using System.Collections.Generic;
using System.Linq;
using LinqBasic.Abstract;

namespace LinqBasic
{
    public class PersonRet : IPersonRetriver
    {
        public IEnumerable<int> GetMalesId(IEnumerable<Person> persons)
        {
            var query = from per in persons
                        where per.PersonGender == Gender.Male
                        select per.Id;
            return query;
        }

        public IEnumerable<Person> GetOddIds(IEnumerable<Person> persons)
        {
            var query = from per in persons
                        where per.Id%2 != 0
                        select per;
            return query;
        }

        public IEnumerable<int> OrderById(IEnumerable<Person> persons)
        {
            var query = from per in persons
                        orderby per.Id descending
                        select per.Id;
                        
            return query;
        }

        IEnumerable<Person> IPersonRetriver.OrderById(IEnumerable<Person> persons)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Abstract.Person> persons = new List<Abstract.Person>()
                                       {
                                           new Person()
                                               {
                                                   Id = 1,
                                                   Name = "Tomer",
                                                   PersonGender = Gender.Male
                                               },
                                           new Person()
                                               {
                                                   Id = 2,
                                                   Name = "Tami",
                                                   PersonGender = Gender.Female
                                               },
                                                                                              new Person()
                                               {
                                                   Id = 3,
                                                   Name = "Nadav",
                                                   PersonGender = Gender.Male
                                               },
                                                                                           new Person()
                                               {
                                                   Id = 4,
                                                   Name = "Roy",
                                                   PersonGender = Gender.Male
                                               },
                                                                                          new Person()
                                               {
                                                   Id = 5,
                                                   Name = "Bar",
                                                   PersonGender = Gender.Female
                                               },

                                       };
            PersonRet r = new PersonRet();
            var a= r.OrderById(persons);
            foreach (var item in a)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
