using System;
using System.Collections.Generic;
using System.Text;
using TalentManagement.Domain.Contracts.Repositories;
using TalentManagement.Domain.Contracts.Services;
using TalentManagement.FactoryServices.Enum;
using TalentManagement.Infrastructure.Repositories;
using TalentManagement.Services;

namespace TalentManagement.FactoryServices
{
    public class FactoryServices
    {
        public FactoryServices() { }

        public static object GetServiceInstance(EnumServices opcao)
        {
            if (opcao == EnumServices.Person)
                return InstanceServicePerson();
            if (opcao == EnumServices.AccountType)
                return InstanceServiceAccountType();
            if (opcao == EnumServices.Bank)
                return InstanceServiceBank();
            if (opcao == EnumServices.City)
                return InstanceServiceCity();
            if (opcao == EnumServices.Knowledge)
                return InstanceServiceKnowledge();
            if (opcao == EnumServices.State)
                return InstanceServiceState();
            if (opcao == EnumServices.TimeWork)
                return InstanceServiceTimeWork();
            if (opcao == EnumServices.Willingness)
                return InstanceServiceWillingness();
            if (opcao == EnumServices.Profile)
                return InstanceServiceProfile();

            return null;
        }

        private static object InstanceServicePerson()
        {
            IRepository repository = FactoryRepository.FactoryRepository.GetRepositoryInstance<PersonRepository>();
            IPersonService service = new PersonService(repository);

            return service;
        }

        private static object InstanceServiceAccountType()
        {
            IRepository repository = FactoryRepository.FactoryRepository.GetRepositoryInstance<AccountTypeRepository>();
            IAccountTypeService service = new AccountTypeService(repository);

            return service;
        }

        private static object InstanceServiceBank()
        {
            IRepository repository = FactoryRepository.FactoryRepository.GetRepositoryInstance<BankRepository>();
            IBankService service = new BankService(repository);

            return service;
        }

        private static object InstanceServiceCity()
        {
            IRepository repository = FactoryRepository.FactoryRepository.GetRepositoryInstance<CityRepository>();
            ICityService service = new CityService(repository);

            return service;
        }

        private static object InstanceServiceKnowledge()
        {
            IRepository repository = FactoryRepository.FactoryRepository.GetRepositoryInstance<KnowledgeRepository>();
            IKnowledgeService service = new KnowledgeService(repository);

            return service;
        }

        private static object InstanceServiceState()
        {
            IRepository repository = FactoryRepository.FactoryRepository.GetRepositoryInstance<StateRepository>();
            IStateService service = new StateService(repository);

            return service;
        }

        private static object InstanceServiceTimeWork()
        {
            IRepository repository = FactoryRepository.FactoryRepository.GetRepositoryInstance<TimeWorkRepository>();
            ITimeWorkService service = new TimeWorkService(repository);

            return service;
        }

        private static object InstanceServiceWillingness()
        {
            IRepository repository = FactoryRepository.FactoryRepository.GetRepositoryInstance<WillingnessRepository>();
            IWillingnessService service = new WillingnessService(repository);

            return service;
        }

        private static object InstanceServiceProfile()
        {
            IRepository repository = FactoryRepository.FactoryRepository.GetRepositoryInstance<ProfileRepository>();
            IProfileService service = new ProfileService(repository);

            return service;
        }
    }
}