using System;
using Bogus;
using KellermanSoftware.CompareNetObjects;
using Moq.AutoMock;
using Social.Domain.Entities;
using Social.Domain.Interfaces;
using Social.Service.Services;
using Xunit;

namespace Social.Test.Service {
    public class BaseServiceTest {

        enum sexo
        {
           M,F     
        }

        [Fact (DisplayName = "Get_Contato_Espero_uma_Lista")]
        [Trait ("BaseService", "Service Tests")]
        public void GetAll_Contatos () {
            //Given
            var mocker = new AutoMocker ();
            var baseServiceMock = mocker.CreateInstance<ContatoService>();
            
            var contatos = GetListContatos();
            var repository = mocker.GetMock<IContatoRepository>();
            repository.Setup( r=> r.SelectAll()).Returns(contatos).Verifiable();


            //When
            var result = baseServiceMock.Get();
            //Then
            var comparison = new CompareLogic();
            Assert.True(comparison.Compare(result,contatos).AreEqual);
            
        }

      public Contato[] GetListContatos(){
          return new Faker<Contato>()
          .CustomInstantiator(f => new Contato{
              Id = f.UniqueIndex,
              DataCadastro = new DateTime(),
              NomeContato = f.Person.FirstName,
              DataNascimento = f.Person.DateOfBirth,
              Sexo = f.Random.Enum<sexo>().ToString()
          }).Generate(10).ToArray();
      }
        
    }

}