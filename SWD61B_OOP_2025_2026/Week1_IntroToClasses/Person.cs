using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1_IntroToClasses
{
    //What is a class?
    //A class is a collection of related attributes which normally represents
    //some real life entity 
    //also known as a blueprint, template....

    //Rules:
    //1. Class names are in singular form
    //2. Class names are in Pascal form e.g ProductCatalog
    //   not good: productcatalog
    //3. No symbols, no spaces, no numbers in names e.g. Person1

    //Access Modifier:
    //Internal - makes the class available for referencing it (using it) only within
    //           this project
    //Public - makes the class available from everywhere (e.g. from other projects)
    public class Person
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Dob {  get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}
