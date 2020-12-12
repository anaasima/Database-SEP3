using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Database_SEP3.Networking;
using Database_SEP3.Persistence.DataAccess;
using Database_SEP3.Persistence.Model;
using Database_SEP3.Persistence.Model.Account;
using Database_SEP3.Persistence.Model.Build;
using Database_SEP3.Persistence.Model.Comment;
using Database_SEP3.Persistence.Model.Forum.Report;
using Database_SEP3.Persistence.Model.Post;
using Database_SEP3.Persistence.Repositories;
using Database_SEP3.Persistence.Repositories.Account;
using Database_SEP3.Persistence.Repositories.Build;
using Database_SEP3.Persistence.Repositories.Forum.Comment;
using Database_SEP3.Persistence.Repositories.Component;
using Database_SEP3.Persistence.Repositories.Forum.Post;
using Database_SEP3.Persistence.Repositories.Forum.Report;
using Database_SEP3.Persistence.Repositories.Rating;
using Microsoft.EntityFrameworkCore;

namespace Database_SEP3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // await PopulateDatabase();
            
            // SocketServer socketServer = new SocketServer();
            // socketServer.StartServer();

        }

        static async Task PopulateDatabase()
        {
            // admin
            AccountRepo accountRepo = new AccountRepo();
            AccountModel admin = new AccountModel()
            {
                Username = "ADMIN",
                Password = "0000",
                Name = "boss"
            };
            await accountRepo.CreateAccount(admin);
            ComponentRepo componentRepo = new ComponentRepo();
            BuildRepo buildRepo = new BuildRepo();
            
            
            //accounts
             AccountModel dummy1 = new AccountModel()
             {
                 Username = "dummy1",
                 Password = "12345",
                 Name = "test1"
             };
             AccountModel dummy2 = new AccountModel()
             {
                 Username = "dummy2",
                 Password = "55555",
                 Name = "test2"
             };
             await accountRepo.CreateAccount(dummy1);
             await accountRepo.CreateAccount(dummy2);
            
            
            //procesoare
            ComponentModel proc1 = new ComponentModel()
            {
                Name = "Ryzen 7 5800X",
                Brand = "AMD",
                ReleaseYear = "2020",
                Type = "CPU",
                SocketType = "AM4",
                EnergyConsumption = 105,
                AdditionalInfo = "3,8 GHz up to 4.7 GHz, 8 cores, 16 threads"
            
            };
            ComponentModel proc2 = new ComponentModel()
            {
                Name = "Ryzen 9 5950X",
                Brand = "AMD",
                ReleaseYear = "2020",
                Type = "CPU",
                SocketType = "AM4",
                EnergyConsumption = 105,
                AdditionalInfo = "3.4 GHz up to 4.9 GHz, 16 cores, 32 threads"
            
            };
            ComponentModel proc3 = new ComponentModel()
            {
                Name = "Ryzen 9 5900X",
                Brand = "AMD",
                ReleaseYear = "2020",
                Type = "CPU",
                SocketType = "AM4",
                EnergyConsumption = 105,
                AdditionalInfo = "3.7 GHz up to 4.8 GHz, 12 cores, 24 threads"
            
            };
            ComponentModel proc4 = new ComponentModel()
            {
                Name = "Ryzen 5 5600X",
                Brand = "AMD",
                ReleaseYear = "2020",
                Type = "CPU",
                SocketType = "AM4",
                EnergyConsumption = 65,
                AdditionalInfo = "3.7 GHz up to 4.6 GHz, 6 cores, 12 threads"
            
            };
            ComponentModel proc5 = new ComponentModel()
            {
                Name = "i9-10850K",
                Brand = "Intel",
                ReleaseYear = "2020",
                Type = "CPU",
                SocketType = "1200 LGA",
                EnergyConsumption = 125,
                AdditionalInfo = "3.6 GHz up to 5.2 GHz, 10 cores, 20 threads"
            
            };
            ComponentModel proc6 = new ComponentModel()
            {
                Name = "i9-10900T",
                Brand = "Intel",
                ReleaseYear = "2020",
                Type = "CPU",
                SocketType = "1200 LGA",
                EnergyConsumption = 35,
                AdditionalInfo = "1.9 GHz up to 4.6 GHz, 10 cores, 20 threads"
            
            };
            ComponentModel proc7 = new ComponentModel()
            {
                Name = "i9-10900",
                Brand = "Intel",
                ReleaseYear = "2020",
                Type = "CPU",
                SocketType = "1200 LGA",
                EnergyConsumption = 65,
                AdditionalInfo = "2.8 GHz up to 5.2 GHz, 10 cores, 20 threads"
            
            };
            ComponentModel proc8 = new ComponentModel()
            {
                Name = "i9-10900K",
                Brand = "Intel",
                ReleaseYear = "2020",
                Type = "CPU",
                SocketType = "1200 LGA",
                EnergyConsumption = 125,
                AdditionalInfo = "3.7 GHz up to 5.3 GHz, 10 cores, 20 threads"
            
            };
            ComponentModel proc9 = new ComponentModel()
            {
                Name = "i9-10980HK",
                Brand = "Intel",
                ReleaseYear = "2020",
                Type = "CPU",
                SocketType = "1440 BGA",
                EnergyConsumption = 45,
                AdditionalInfo = "2.4 GHz up to 5.3 GHz, 8 cores, 16 threads"
            
            };
            
            await componentRepo.CreateComponent(proc1);
            await componentRepo.CreateComponent(proc2);
            await componentRepo.CreateComponent(proc3);
            await componentRepo.CreateComponent(proc4);
            await componentRepo.CreateComponent(proc5);
            await componentRepo.CreateComponent(proc6);
            await componentRepo.CreateComponent(proc7);
            await componentRepo.CreateComponent(proc8);
            await componentRepo.CreateComponent(proc9);
            
            // placi video
            ComponentModel gpu1 = new ComponentModel()
            {
                Name = "Radeon RX 6800",
                Brand = "AMD",
                ReleaseYear = "2020",
                Type = "GPU",
                SocketType = "PCIe 4.0 x16",
                EnergyConsumption = 250,
                AdditionalInfo = "1815 MHz, 16 GB GDDR6, 256 bit"
            
            };
            ComponentModel gpu2 = new ComponentModel()
            {
                Name = "Radeon RX 6800 XT",
                Brand = "AMD",
                ReleaseYear = "2020",
                Type = "GPU",
                SocketType = "PCIe 4.0 x16",
                EnergyConsumption = 300,
                AdditionalInfo = "2015 MHz, 16 GB GDDR6, 256 bit"
            
            };
            ComponentModel gpu3 = new ComponentModel()
            {
                Name = "Radeon RX 6900 XT",
                Brand = "AMD",
                ReleaseYear = "2020",
                Type = "GPU",
                SocketType = "PCIe 4.0 x16",
                EnergyConsumption = 300,
                AdditionalInfo = "2015 MHz, 16 GB GDDR6, 256 bit"
            
            };
            ComponentModel gpu4 = new ComponentModel()
            {
                Name = "GeForce RTX 3090",
                Brand = "NVIDIA",
                ReleaseYear = "2020",
                Type = "GPU",
                SocketType = "PCIe 4.0 x16",
                EnergyConsumption = 350,
                AdditionalInfo = "1400 MHz, 24 GB GDDR6X, 384 bit"
            
            };
            ComponentModel gpu5 = new ComponentModel()
            {
                Name = "GeForce RTX 3080",
                Brand = "NVIDIA",
                ReleaseYear = "2020",
                Type = "GPU",
                SocketType = "PCIe 4.0 x16",
                EnergyConsumption = 320,
                AdditionalInfo = "1440 MHz, 10 GB GDDR6X, 320 bit"
            
            };
            ComponentModel gpu6 = new ComponentModel()
            {
                Name = "GeForce RTX 3070",
                Brand = "NVIDIA",
                ReleaseYear = "2020",
                Type = "GPU",
                SocketType = "PCIe 4.0 x16",
                EnergyConsumption = 220,
                AdditionalInfo = "1500 MHz, 8 GB GDDR6, 256 bit"
            
            };
            ComponentModel gpu7 = new ComponentModel()
            {
                Name = "GeForce RTX 3060 Ti",
                Brand = "NVIDIA",
                ReleaseYear = "2020",
                Type = "GPU",
                SocketType = "PCIe 4.0 x16",
                EnergyConsumption = 200,
                AdditionalInfo = "1500 MHz, 8 GB GDDR6, 256 bit"
            };
            
            await componentRepo.CreateComponent(gpu1);
            await componentRepo.CreateComponent(gpu2);
            await componentRepo.CreateComponent(gpu3);
            await componentRepo.CreateComponent(gpu4);
            await componentRepo.CreateComponent(gpu5);
            await componentRepo.CreateComponent(gpu6);
            await componentRepo.CreateComponent(gpu7);
            
            
            // memorie RAM
            ComponentModel ram1 = new ComponentModel()
            {
                Name = "ValueRam KVR13N9K2/16",
                Brand = "Kingston",
                ReleaseYear = "2015",
                Type = "RAM",
                SocketType = "DDR3",
                EnergyConsumption = 0,
                AdditionalInfo = "2x8GB kit, DDR3-1333 CL9"
            
            };
            ComponentModel ram2 = new ComponentModel()
            {
                Name = "Viper Elite Gray",
                Brand = "Patriot",
                ReleaseYear = "2019",
                Type = "RAM",
                SocketType = "DDR4",
                EnergyConsumption = 0,
                AdditionalInfo = "2x4GB kit, DDR4-2666 CL16"
            
            };
            ComponentModel ram3 = new ComponentModel()
            {
                Name = "VENGEANCE RGB PRO 16",
                Brand = "Corsair",
                ReleaseYear = "2018",
                Type = "RAM",
                SocketType = "DDR4",
                EnergyConsumption = 0,
                AdditionalInfo = "2x8GB kit, DDR4-3000 CL15"
            
            };
            ComponentModel ram4 = new ComponentModel()
            {
                Name = "ValueRam KVR16S11K2/16",
                Brand = "Kingston",
                ReleaseYear = "2015",
                Type = "RAM",
                SocketType = "DDR3",
                EnergyConsumption = 0,
                AdditionalInfo = "2x8GB kit, DDR3-1600 CL11"
            
            };
            ComponentModel ram5 = new ComponentModel()
            {
                Name = "Premier 16",
                Brand = "ADATA",
                ReleaseYear = "2016",
                Type = "RAM",
                SocketType = "DDR4",
                EnergyConsumption = 0,
                AdditionalInfo = "2x8GB kit, DDR4-2400 CL17"
            
            };
            ComponentModel ram6 = new ComponentModel()
            {
                Name = "XPG Gammix D10",
                Brand = "ADATA",
                ReleaseYear = "2018",
                Type = "RAM",
                SocketType = "DDR4",
                EnergyConsumption = 0,
                AdditionalInfo = "2x8GB kit, DDR4-3200 CL16"
            
            };
            ComponentModel ram7 = new ComponentModel()
            {
                Name = "Fury RGB",
                Brand = "HyperX",
                ReleaseYear = "2019",
                Type = "RAM",
                SocketType = "DDR4",
                EnergyConsumption = 0,
                AdditionalInfo = "2x16GB kit, DDR4-3200 CL16"
            
            };
            ComponentModel ram8 = new ComponentModel()
            {
                Name = "Viper 4",
                Brand = "Patriot",
                ReleaseYear = "2019",
                Type = "RAM",
                SocketType = "DDR4",
                EnergyConsumption = 0,
                AdditionalInfo = "2x16GB kit, DDR4-3000 CL16"
            
            };
            await componentRepo.CreateComponent(ram1);
            await componentRepo.CreateComponent(ram2);
            await componentRepo.CreateComponent(ram3);
            await componentRepo.CreateComponent(ram4);
            await componentRepo.CreateComponent(ram5);
            await componentRepo.CreateComponent(ram6);
            await componentRepo.CreateComponent(ram7);
            await componentRepo.CreateComponent(ram8);
            
            
            //storage
            ComponentModel stor1 = new ComponentModel()
            {
                Name = "P300 HDD",
                Brand = "Toshiba",
                ReleaseYear = "2018",
                Type = "Storage",
                SocketType = "SATA-III",
                EnergyConsumption = 0,
                AdditionalInfo = "2TB, 7200rpm, 64MB buffer, 3.5inch"
            
            };
            ComponentModel stor2 = new ComponentModel()
            {
                Name = "BarraCuda HDD",
                Brand = "Seagate",
                ReleaseYear = "2018",
                Type = "Storage",
                SocketType = "SATA-III",
                EnergyConsumption = 0,
                AdditionalInfo = "1TB, 7200 rpm, 64MB buffer, 3.5inch"
            
            };
            ComponentModel stor3 = new ComponentModel()
            {
                Name = "Blue HDD",
                Brand = "WD",
                ReleaseYear = "2019",
                Type = "Storage",
                SocketType = "SATA-III",
                EnergyConsumption = 0,
                AdditionalInfo = "1TB, 7200 rpm, 64MB buffer, 3.5inch"
            
            };
            ComponentModel stor4 = new ComponentModel()
            {
                Name = "P2 SSD",
                Brand = "Crucial",
                ReleaseYear = "2017",
                Type = "Storage",
                SocketType = "NVMe",    
                EnergyConsumption = 0,
                AdditionalInfo = "500GB, 940MB/s - 2300MB/s, M.2"
            
            };
            ComponentModel stor5 = new ComponentModel()
            {
                Name = "A400 SSD",
                Brand = "Kingston",
                ReleaseYear = "2018",
                Type = "Storage",
                SocketType = "SATA-III",
                EnergyConsumption = 0,
                AdditionalInfo = "240GB, 350MB/s - 500MB/s, 2.5inch"
            
            };
            await componentRepo.CreateComponent(stor1);
            await componentRepo.CreateComponent(stor2);
            await componentRepo.CreateComponent(stor3);
            await componentRepo.CreateComponent(stor4);
            await componentRepo.CreateComponent(stor5);
            
            
            //power supply 
            ComponentModel supply1 = new ComponentModel()
            {
                Name = "S12III-550",
                Brand = "Seasonic",
                ReleaseYear = "2018",
                Type = "Power supply",
                SocketType = "",
                EnergyConsumption = 550,
                AdditionalInfo = "85%, 80+ Bronze"
            };
            ComponentModel supply2 = new ComponentModel()
            {
                Name = "CV650",
                Brand = "Corsair",
                ReleaseYear = "2019",
                Type = "Power supply",
                SocketType = "",
                EnergyConsumption = 650,
                AdditionalInfo = "88%, 80+ Bronze"
            };
            ComponentModel supply3 = new ComponentModel()
            {
                Name = "System Power 9 500",
                Brand = "bequiet!",
                ReleaseYear = "2020",
                Type = "Power supply",
                SocketType = "",
                EnergyConsumption = 500,
                AdditionalInfo = "88%, 80+ Bronze"
            };
            ComponentModel supply4 = new ComponentModel()
            {
                Name = "Power Zone 850",
                Brand = "bequiet!",
                ReleaseYear = "2020",
                Type = "Power supply",
                SocketType = "",
                EnergyConsumption = 850,
                AdditionalInfo = "88%, 80+ Bronze"
            };
            ComponentModel supply5 = new ComponentModel()
            {
                Name = "MWE GOLD 650",
                Brand = "Cooler Master",
                ReleaseYear = "2019",
                Type = "Power supply",
                SocketType = "",
                EnergyConsumption = 650,
                AdditionalInfo = "90%, 80+ Gold, Modular"
            };
            ComponentModel supply6 = new ComponentModel()
            {
                Name = "C750",
                Brand = "NZXT",
                ReleaseYear = "2019",
                Type = "Power supply",
                SocketType = "",
                EnergyConsumption = 750,
                AdditionalInfo = "90%, 80+ Gold, Modular"
            };
            await componentRepo.CreateComponent(supply1);
            await componentRepo.CreateComponent(supply2);
            await componentRepo.CreateComponent(supply3);
            await componentRepo.CreateComponent(supply4);
            await componentRepo.CreateComponent(supply5);
            await componentRepo.CreateComponent(supply6);
            
            
            //placi de baza
            ComponentModel mb1 = new ComponentModel()
            {
                Name = "B365M PRO-VH",
                Brand = "MSI",
                ReleaseYear = "2018",
                Type = "Motherboard",
                SocketType = "1151v2, PCIe 3.0 x16, DDR4, SATA-III",
                EnergyConsumption = 0,
                AdditionalInfo = "mATX"
            };
            ComponentModel mb2 = new ComponentModel()
            {
                Name = "PRIME B460-PLUS",
                Brand = "ASUS",
                ReleaseYear = "2020",
                Type = "Motherboard",
                SocketType = "1200 LGA, PCIe 4.0 x16, DDR4, SATA-III, NVMe",
                EnergyConsumption = 0,
                AdditionalInfo = "ATX"
            };
            ComponentModel mb3 = new ComponentModel()
            {
                Name = "B450 AORUS ELITE",
                Brand = "GIGABYTE",
                ReleaseYear = "2019",
                Type = "Motherboard",
                SocketType = "AM4, PCIe 3.0 x16, DDR4, SATA-III",
                EnergyConsumption = 0,
                AdditionalInfo = "ATX"
            };
            ComponentModel mb4 = new ComponentModel()
            {
                Name = "X570-A PRO",
                Brand = "MSI",
                ReleaseYear = "2020",
                Type = "Motherboard",
                SocketType = "AM4, PCIe 4.0 x16, DDR4, SATA-III, NVMe",
                EnergyConsumption = 0,
                AdditionalInfo = "ATX"
            };
            ComponentModel mb5 = new ComponentModel()
            {
                Name = "Z490-A PRO",
                Brand = "MSI",
                ReleaseYear = "2018",
                Type = "Motherboard",
                SocketType = "1200 LGA, PCIe 3.0 x16, DDR4, SATA-III",
                EnergyConsumption = 0,
                AdditionalInfo = "ATX"
            };
            await componentRepo.CreateComponent(mb1);
            await componentRepo.CreateComponent(mb2);
            await componentRepo.CreateComponent(mb3);
            await componentRepo.CreateComponent(mb4);
            await componentRepo.CreateComponent(mb5);
            
            
            // gpu pcie 3
             ComponentModel pcie1 = new ComponentModel()
             {
                 Name = "GeForce GTX 1650",
                 Brand = "NVIDIA",
                 ReleaseYear = "2019",
                 Type = "GPU",
                 SocketType = "PCIe 3.0 x16",
                 EnergyConsumption = 75,
                 AdditionalInfo = "1485 MHz, 4 GB GDDR5, 128 bit"
             };
             ComponentModel pcie2 = new ComponentModel()
             {
                 Name = "GeForce RTX 2060",
                 Brand = "NVIDIA",
                 ReleaseYear = "2018",
                 Type = "GPU",
                 SocketType = "PCIe 3.0 x16",
                 EnergyConsumption = 160,
                 AdditionalInfo = "1365 MHz, 6 GB GDDR6, 192 bit"
             };
             await componentRepo.CreateComponent(pcie1);
             await componentRepo.CreateComponent(pcie2);
             
             
             // cpu 1151v2
              ComponentModel cpuaa = new ComponentModel()
              {
                  Name = "i5-9600K",
                  Brand = "Intel",
                  ReleaseYear = "2018",
                  Type = "CPU",
                  SocketType = "1151v2",
                  EnergyConsumption = 95,
                  AdditionalInfo = "3.7 GHz up to 4.6 GHz, 6 cores, 6 threads"
              };
              ComponentModel cpubb = new ComponentModel()
              {
                  Name = "i7-9700K",
                  Brand = "Intel",
                  ReleaseYear = "2018",
                  Type = "CPU",
                  SocketType = "1151v2",
                  EnergyConsumption = 95,
                  AdditionalInfo = "3.6 GHz up to 4.9 GHz, 8 cores, 8 threads"
              };
              await componentRepo.CreateComponent(cpuaa);
              await componentRepo.CreateComponent(cpubb);
            
            
            
            // prebuilds
            // p1
             ComponentModel pb1c1 = new ComponentModel()
             {
                 Name = "i3-9100",
                 Brand = "Intel",
                 ReleaseYear = "2019",
                 Type = "CPU",
                 SocketType = "1151v2",
                 EnergyConsumption = 65,
                 AdditionalInfo = "3.6 GHz up to 4.2 GHz, 4 cores, 4 threads"
             };
             ComponentModel pb1c2 = new ComponentModel()
             {
                 Name = "H310M PRO-M2 PLUS",
                 Brand = "MSI",
                 ReleaseYear = "2019",
                 Type = "Motherboard",
                 SocketType = "1151v2, PCIe 3.0 x16, DDR4, SATA-III",
                 EnergyConsumption = 0,
                 AdditionalInfo = "mATX"
             };
             ComponentModel pb1c3 = new ComponentModel()
             {
                 Name = "Fury Black",
                 Brand = "HyperX",
                 ReleaseYear = "2018",
                 Type = "RAM",
                 SocketType = "DDR4",
                 EnergyConsumption = 0,
                 AdditionalInfo = "2x8GB kit, DDR4-2400 CL15"
             };
            ComponentModel pb1c4 = new ComponentModel()
            {
                Name = "High Performance SSD",
                Brand = "Intenso",
                ReleaseYear = "2018",
                Type = "Storage",
                SocketType = "SATA-III",
                EnergyConsumption = 0,
                AdditionalInfo = "480GB, 520MB/s - 500MB/s, 2.5inch"
            };
            ComponentModel pb1c5 = new ComponentModel()
            {
                Name = "FL500-12",
                Brand = "Floston",
                ReleaseYear = "2015",
                Type = "Power supply",
                SocketType = "",
                EnergyConsumption = 500,
                AdditionalInfo = "Not certified"
            };
            await componentRepo.CreateComponent(pb1c1);
            await componentRepo.CreateComponent(pb1c2);
            await componentRepo.CreateComponent(pb1c3);
            await componentRepo.CreateComponent(pb1c4);
            await componentRepo.CreateComponent(pb1c5);
            IList<ComponentModel> list1 = new Collection<ComponentModel>();
            list1.Add(await componentRepo.GetComponentByName("i3-9100"));
            list1.Add(await componentRepo.GetComponentByName("H310M PRO-M2 PLUS"));
            list1.Add(await componentRepo.GetComponentByName("Fury Black"));
            list1.Add(await componentRepo.GetComponentByName("High Performance SSD"));
            list1.Add(await componentRepo.GetComponentByName("FL500-12"));
            BuildModel pre1 = new BuildModel()
            {
                AccountModelUserId = 1,
                Name = "Office Computer",
                ComponentList = list1
            };
            await buildRepo.CreateBuild(pre1);

            // p2
            ComponentModel pb2c4 = new ComponentModel()
            {
                Name = "Red Pro HDD",
                Brand = "WD",
                ReleaseYear = "2019",
                Type = "Storage",
                SocketType = "SATA-III",
                EnergyConsumption = 0,
                AdditionalInfo = "4TB, 7200 rpm, 256MB buffer, 3.5inch"
            };
            await componentRepo.CreateComponent(pb2c4);
            IList<ComponentModel> list2 = new Collection<ComponentModel>();
            list2.Add(await componentRepo.GetComponentByName("Ryzen 7 5800X")); //5800x
            list2.Add(await componentRepo.GetComponentByName("Radeon RX 6800")); //6800
            list2.Add(await componentRepo.GetComponentByName("X570-A PRO")); //msi x570
            list2.Add(await componentRepo.GetComponentByName("Viper 4")); //patriot
            list2.Add(await componentRepo.GetComponentByName("CV650"));//corsair
            list2.Add(await componentRepo.GetComponentByName("Red Pro HDD"));//wd 4tb
            BuildModel pre2 = new BuildModel()
            {
                AccountModelUserId = 1,
                Name = "Workstation Computer",
                ComponentList = list2
            };
            await buildRepo.CreateBuild(pre2);
            
            // p3
            IList<ComponentModel> list3 = new Collection<ComponentModel>();
            list3.Add(await componentRepo.GetComponentByName("i9-10900K")); //10900k
            list3.Add(await componentRepo.GetComponentByName("GeForce RTX 3090")); //3090
            list3.Add(await componentRepo.GetComponentByName("PRIME B460-PLUS")); //asus b460
            list3.Add(await componentRepo.GetComponentByName("Fury RGB")); //hyperx rgb
            list3.Add(await componentRepo.GetComponentByName("Blue HDD")); //wd blue
            list3.Add(await componentRepo.GetComponentByName("C750")); //nzxt
            BuildModel pre3 = new BuildModel()
            {
                AccountModelUserId = 1,
                Name = "Gaming Computer",
                ComponentList = list3
            };
            await buildRepo.CreateBuild(pre3);
            
            
            //posts
             PostRepo postRepo = new PostRepo();
             PostModel p1 = new PostModel()
             {
                 AccountModelUserId = 2,
                 Content = "The United States Declaration of Independence (formally The unanimous Declaration of the thirteen united States of America) is the pronouncement adopted by the Second Continental Congress meeting in Philadelphia, Pennsylvania, on July 4, 1776.",
             };
             PostModel p2 = new PostModel()
             {
                 AccountModelUserId = 2,
                 Content = "During his youth, Alexander was tutored by Aristotle until age 16. After Philip's assassination in 336 BC, he succeeded his father to the throne and inherited a strong kingdom and an experienced army."
             };
             PostModel p3 = new PostModel()
             {
                 AccountModelUserId = 3,
                 Content = "Night City is an American megacity in the Free State of North California, controlled by corporations and unassailed by the laws of both country and state. It sees conflict from rampant gang wars and its ruling entities contending for dominance."
             };
             await postRepo.CreatePost(p1);
             await postRepo.CreatePost(p2);
             await postRepo.CreatePost(p3);
             
             
             //comments
             CommentRepo commentRepo = new CommentRepo();
             CommentModel c1 = new CommentModel()
             {
                 AccountModelUserId = 3,
                 Content = "The most famous Egyptian pyramids are those found at Giza, on the outskirts of Cairo. Several of the Giza pyramids are counted among the largest structures ever built. The Pyramid of Khufu is the largest Egyptian pyramid.",
                 PostModelId = 1
             };
             CommentModel c2 = new CommentModel()
             {
                 AccountModelUserId = 2,
                 Content = "As the tanuki, the animal has been significant in Japanese folklore since ancient times. The legendary tanuki is reputed to be mischievous and jolly, a master of disguise and shapeshifting, but somewhat gullible and absentminded.",
                 PostModelId = 3
             };
             await commentRepo.CreateComment(c1);
             await commentRepo.CreateComment(c2);
        }
    }
}