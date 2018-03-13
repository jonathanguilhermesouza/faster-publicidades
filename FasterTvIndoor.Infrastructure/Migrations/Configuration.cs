namespace FasterTvIndoor.Infrastructure.Migrations
{
    using FasterTvIndoor.Domain.FasterAdministration.Entities;
    using FasterTvIndoor.Domain.FasterAdministration.Enum;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FasterTvIndoor.Infrastructure.Persistence.DataContexts.FasterTvIndoorDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FasterTvIndoor.Infrastructure.Persistence.DataContexts.FasterTvIndoorDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Equipment equipament1 = new Equipment(1, 1, "teste 1", "avbs", "123456", DateTime.Now, "terter");
            //Equipment equipament2 = new Equipment(2, 1, "teste 2", "avbs", "999999", DateTime.Now, "aaaaaa");

            //List<Equipment> listEquipment = new List<Equipment>();
            //listEquipment.Add(equipament1);
            //listEquipment.Add(equipament2);

            //context.Video.AddOrUpdate(new Video(1, "www.eu.com.br", 10, EStatusVideo.Ativo, listEquipment, 1, 1, 1));
            //context.Video.AddOrUpdate(new Video(2, "www.eu.com.br2", 10, EStatusVideo.Ativo, listEquipment, 1, 1, 1));


            context.ProfileUser.AddOrUpdate(new ProfileUser(1, "Cliente"));
            context.ProfileUser.AddOrUpdate(new ProfileUser(2, "PlayerIndoor"));
            context.ProfileUser.AddOrUpdate(new ProfileUser(3, "Operacional"));
            context.ProfileUser.AddOrUpdate(new ProfileUser(4, "Suporte"));
            context.ProfileUser.AddOrUpdate(new ProfileUser(5, "Administrador"));
            context.ProfileUser.AddOrUpdate(new ProfileUser(6, "Master"));
            //context.StatusUser.AddOrUpdate(new StatusUser(1,"Ativo"));

            //Criação das empresas
            context.Company.AddOrUpdate(new Company(1, "Faster Tecnologia", "Technologic", "99999", "4545454540001", "contato@fastertecnologia.com.br", EClassificationCompany.Matriz, EStatusCompany.Ativa, ESizeCompany.Grande));
            //context.Company.AddOrUpdate(new Company(2, "Faster Technologic 2", "Faster 2", "99999", "4545454540001", "faster@faster.com.br", EClassificationCompany.Matriz, EStatusCompany.Ativa, ESizeCompany.Grande));
            //context.Company.AddOrUpdate(new Company(3, "Faster Technologic 3", "Faster 3", "99999", "4545454540001", "faster@faster.com.br", EClassificationCompany.Matriz, EStatusCompany.Ativa, ESizeCompany.Grande));
            //context.Company.AddOrUpdate(new Company(4, "Faster Technologic 4", "Faster 4", "99999", "4545454540001", "faster@faster.com.br", EClassificationCompany.Matriz, EStatusCompany.Ativa, ESizeCompany.Grande));
            //context.Company.AddOrUpdate(new Company(5, "Faster Technologic 5", "Faster 5", "99999", "4545454540001", "faster@faster.com.br", EClassificationCompany.Matriz, EStatusCompany.Ativa, ESizeCompany.Grande));
            //context.Company.AddOrUpdate(new Company(6, "Faster Technologic 6", "Faster 6", "99999", "4545454540001", "faster@faster.com.br", EClassificationCompany.Matriz, EStatusCompany.Ativa, ESizeCompany.Grande));
            //context.Company.AddOrUpdate(new Company(7, "Faster Technologic 7", "Faster 7", "99999", "4545454540001", "faster@faster.com.br", EClassificationCompany.Matriz, EStatusCompany.Ativa, ESizeCompany.Grande));
            //context.Company.AddOrUpdate(new Company(8, "Faster Technologic 8", "Faster 8", "99999", "4545454540001", "faster@faster.com.br", EClassificationCompany.Matriz, EStatusCompany.Ativa, ESizeCompany.Grande));
            //context.Company.AddOrUpdate(new Company(9, "Faster Technologic 9", "Faster 9", "99999", "4545454540001", "faster@faster.com.br", EClassificationCompany.Matriz, EStatusCompany.Ativa, ESizeCompany.Grande));
            //context.Company.AddOrUpdate(new Company(10, "Faster Technologic 10", "Faster 10", "99999", "4545454540001", "faster@faster.com.br", EClassificationCompany.Matriz, EStatusCompany.Ativa, ESizeCompany.Grande));
            //context.Company.AddOrUpdate(new Company(11, "Faster Technologic 11", "Faster 11", "99999", "4545454540001", "faster@faster.com.br", EClassificationCompany.Matriz, EStatusCompany.Ativa, ESizeCompany.Grande));
            //context.Company.AddOrUpdate(new Company(12, "Faster Technologic 12", "Faster 12", "99999", "4545454540001", "faster@faster.com.br", EClassificationCompany.Matriz, EStatusCompany.Ativa, ESizeCompany.Grande));
            //context.Company.AddOrUpdate(new Company(13, "Faster Technologic 13", "Faster 13", "99999", "4545454540001", "faster@faster.com.br", EClassificationCompany.Matriz, EStatusCompany.Ativa, ESizeCompany.Grande));
            //context.Company.AddOrUpdate(new Company(14, "Faster Technologic 14", "Faster 14", "99999", "4545454540001", "faster@faster.com.br", EClassificationCompany.Matriz, EStatusCompany.Ativa, ESizeCompany.Grande));
            
            //Criação do Telefone das empresas
            context.PhoneCompany.AddOrUpdate(new PhoneCompany(1, "012999999999", 1));
            //context.PhoneCompany.AddOrUpdate(new PhoneCompany(2, "012999999999", 2));
            //context.PhoneCompany.AddOrUpdate(new PhoneCompany(3, "012999999999", 3));
            //context.PhoneCompany.AddOrUpdate(new PhoneCompany(4, "012999999999", 4));
            //context.PhoneCompany.AddOrUpdate(new PhoneCompany(5, "012999999999", 5));
            //context.PhoneCompany.AddOrUpdate(new PhoneCompany(6, "012999999999", 6));
            //context.PhoneCompany.AddOrUpdate(new PhoneCompany(7, "012999999999", 7));
            //context.PhoneCompany.AddOrUpdate(new PhoneCompany(8, "012999999999", 8));
            //context.PhoneCompany.AddOrUpdate(new PhoneCompany(9, "012999999999", 9));
            //context.PhoneCompany.AddOrUpdate(new PhoneCompany(10, "012999999999", 10));
            //context.PhoneCompany.AddOrUpdate(new PhoneCompany(11, "012999999999", 11));
            //context.PhoneCompany.AddOrUpdate(new PhoneCompany(12, "012999999999", 12));
            //context.PhoneCompany.AddOrUpdate(new PhoneCompany(13, "012999999999", 13));
            //context.PhoneCompany.AddOrUpdate(new PhoneCompany(14, "012999999999", 14));


            //context.User.AddOrUpdate(new User("jonathan@gmail.com", "@!Nf0#10", true,1, 1));

            ////Criação de Funcionário
            //context.EmployedCompany.AddOrUpdate(new EmployedCompany("39461778830", 1, 1, 1));


            //Criação do Setor
            context.SectorCompany.AddOrUpdate(new SectorCompany(1, "Administracao"));
            context.SectorCompany.AddOrUpdate(new SectorCompany(2, "Caixa"));
            context.SectorCompany.AddOrUpdate(new SectorCompany(3, "Cozinha"));
            context.SectorCompany.AddOrUpdate(new SectorCompany(4, "Bar"));

            //context.User.AddOrUpdate();

            //Criação de Funcionário
            //context.EmployeeCompany.AddOrUpdate(new EmployeeCompany("39461778830", 1, 1, new User("jonathan@gmail.com", "@!Nf0#10", true, 1, 1)));

            
        }
    }
}
