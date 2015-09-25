namespace UltimateManagementTool.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;

    using GalaSoft.MvvmLight;

    using Tynamix.ObjectFiller;

    using UltimateManagementTool.Interfaces;

    public class PersonSelectionViewModel : ViewModelBase
    {
        private readonly IRepository repository;

        public PersonSelectionViewModel(IRepository repository)
        {
            this.repository = repository;
        }

        public PersonSelectionViewModel()
        {
            var filler = new Filler<Person>();
            this.Persons = filler.Create(4).ToList();
        }

        public void OnShow()
        {
            this.Persons = this.repository.GetPersons();
        }

        private IEnumerable<Person> persons;

        public IEnumerable<Person> Persons
        {
            get
            {
                return this.persons;
            }
            set
            {
                this.Set(() => this.Persons, ref this.persons, value);
            }
        }
    }
}