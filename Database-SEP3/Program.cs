﻿using System;
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
            SocketServer socketServer = new SocketServer();
            socketServer.StartServer();


            // admin
            // AccountRepo accountRepo = new AccountRepo();
            // AccountModel admin = new AccountModel()
            // {
            //     Username = "ADMIN",
            //     Password = "0000",
            //     Name = "boss"
            // };
            // await accountRepo.CreateAccount(admin);
            // ComponentRepo componentRepo = new ComponentRepo();
            // BuildRepo buildRepo = new BuildRepo();
            //prebuilds
            //p1
            // ComponentModel pb1c1 = new ComponentModel()
            // {
            //     Name = "i3-9100",
            //     Brand = "Intel",
            //     ReleaseYear = "2019",
            //     Type = "CPU",
            //     SocketType = "1151v2",
            //     EnergyConsumption = 65,
            //     AdditionalInfo = "3.6 GHz up to 4.2 GHz, 4 cores, 4 threads"
            // };
            // ComponentModel pb1c2 = new ComponentModel()
            // {
            //     Name = "H310M PRO-M2 PLUS",
            //     Brand = "MSI",
            //     ReleaseYear = "2019",
            //     Type = "Motherboard",
            //     SocketType = "1151v2, PCIe 3.0 x16, DDR4, SATA-III",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "mATX"
            // };
            // ComponentModel pb1c3 = new ComponentModel()
            // {
            //     Name = "Fury Black",
            //     Brand = "HyperX",
            //     ReleaseYear = "2018",
            //     Type = "RAM",
            //     SocketType = "DDR4",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "2x8GB kit, DDR4-2400 CL15"
            // };
            // ComponentModel pb1c4 = new ComponentModel()
            // {
            //     Name = "High Performance SSD",
            //     Brand = "Intenso",
            //     ReleaseYear = "2018",
            //     Type = "Storage",
            //     SocketType = "SATA-III",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "480GB, 520MB/s - 500MB/s, 2.5inch"
            // };
            // ComponentModel pb1c5 = new ComponentModel()
            // {
            //     Name = "FL500-12",
            //     Brand = "Floston",
            //     ReleaseYear = "2015",
            //     Type = "Power supply",
            //     SocketType = "",
            //     EnergyConsumption = 500,
            //     AdditionalInfo = "Not certified"
            // };
            // await componentRepo.CreateComponent(pb1c1);
            // await componentRepo.CreateComponent(pb1c2);
            // await componentRepo.CreateComponent(pb1c3);
            // await componentRepo.CreateComponent(pb1c4);
            // await componentRepo.CreateComponent(pb1c5);
            // IList<ComponentModel> list1 = new Collection<ComponentModel>();
            // list1.Add(await componentRepo.GetComponentById(41));
            // list1.Add(await componentRepo.GetComponentById(42));
            // list1.Add(await componentRepo.GetComponentById(43));
            // list1.Add(await componentRepo.GetComponentById(44));
            // list1.Add(await componentRepo.GetComponentById(45));
            // BuildModel pre1 = new BuildModel()
            // {
            //     AccountModelUserId = 3,
            //     Name = "Office Computer",
            //     ComponentList = list1
            // };
            // await buildRepo.CreateBuild(pre1);
            
             //p2
            // ComponentModel pb2c1 = new ComponentModel()
            // {
            //     Name = "i3-9100",
            //     Brand = "Intel",
            //     ReleaseYear = "2019",
            //     Type = "CPU",
            //     SocketType = "1151v2",
            //     EnergyConsumption = 65,
            //     AdditionalInfo = "3.6 GHz up to 4.2 GHz, 4 cores, 4 threads"
            // };
            // ComponentModel pb2c2 = new ComponentModel()
            // {
            //     Name = "H310M PRO-M2 PLUS",
            //     Brand = "MSI",
            //     ReleaseYear = "2019",
            //     Type = "Motherboard",
            //     SocketType = "1151v2, PCIe 3.0 x16, DDR4, SATA-III",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "mATX"
            // };
            // ComponentModel pb2c3 = new ComponentModel()
            // {
            //     Name = "Fury Black",
            //     Brand = "HyperX",
            //     ReleaseYear = "2018",
            //     Type = "RAM",
            //     SocketType = "DDR4",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "2x8GB kit, DDR4-2400 CL15"
            // };
            // ComponentModel pb2c4 = new ComponentModel()
            // {
            //     Name = "Red Pro HDD",
            //     Brand = "WD",
            //     ReleaseYear = "2019",
            //     Type = "Storage",
            //     SocketType = "SATA-III",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "4TB, 7200 rpm, 256MB buffer, 3.5inch"
            // };
            // ComponentModel pb2c5 = new ComponentModel()
            // {
            //     Name = "FL500-12",
            //     Brand = "Floston",
            //     ReleaseYear = "2015",
            //     Type = "Power supply",
            //     SocketType = "",
            //     EnergyConsumption = 500,
            //     AdditionalInfo = "Not certified"
            // };
            // await componentRepo.CreateComponent(pb1c1);
            // await componentRepo.CreateComponent(pb1c2);
            // await componentRepo.CreateComponent(pb1c3);
            // await componentRepo.CreateComponent(pb2c4);
            // await componentRepo.CreateComponent(pb1c5);
            // IList<ComponentModel> list2 = new Collection<ComponentModel>();
            // list2.Add(await componentRepo.GetComponentById(6)); //5800x
            // list2.Add(await componentRepo.GetComponentById(15)); //6800
            // list2.Add(await componentRepo.GetComponentById(44)); //msi x570
            // list2.Add(await componentRepo.GetComponentById(29)); //patriot
            // list2.Add(await componentRepo.GetComponentById(36));//corsair
            // list2.Add(await componentRepo.GetComponentById(51));//wd 4tb
            // BuildModel pre2 = new BuildModel()
            // {
            //     AccountModelUserId = 3,
            //     Name = "Workstation Computer",
            //     ComponentList = list2
            // };
            // await buildRepo.CreateBuild(pre2);
            
             //p3
            // ComponentModel pb3c1 = new ComponentModel()
            // {
            //     Name = "i3-9100",
            //     Brand = "Intel",
            //     ReleaseYear = "2019",
            //     Type = "CPU",
            //     SocketType = "1151v2",
            //     EnergyConsumption = 65,
            //     AdditionalInfo = "3.6 GHz up to 4.2 GHz, 4 cores, 4 threads"
            // };
            // ComponentModel pb3c2 = new ComponentModel()
            // {
            //     Name = "H310M PRO-M2 PLUS",
            //     Brand = "MSI",
            //     ReleaseYear = "2019",
            //     Type = "Motherboard",
            //     SocketType = "1151v2, PCIe 3.0 x16, DDR4, SATA-III",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "mATX"
            // };
            // ComponentModel pb3c3 = new ComponentModel()
            // {
            //     Name = "Fury Black",
            //     Brand = "HyperX",
            //     ReleaseYear = "2018",
            //     Type = "RAM",
            //     SocketType = "DDR4",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "2x8GB kit, DDR4-2400 CL15"
            // };
            // ComponentModel pb3c4 = new ComponentModel()
            // {
            //     Name = "Red Pro HDD",
            //     Brand = "WD",
            //     ReleaseYear = "2019",
            //     Type = "Storage",
            //     SocketType = "SATA-III",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "4TB, 7200 rpm, 256MB buffer, 3.5inch"
            // };
            // ComponentModel pb3c5 = new ComponentModel()
            // {
            //     Name = "FL500-12",
            //     Brand = "Floston",
            //     ReleaseYear = "2015",
            //     Type = "Power supply",
            //     SocketType = "",
            //     EnergyConsumption = 500,
            //     AdditionalInfo = "Not certified"
            // };
            // await componentRepo.CreateComponent(pb1c1);
            // await componentRepo.CreateComponent(pb1c2);
            // await componentRepo.CreateComponent(pb1c3);
            // await componentRepo.CreateComponent(pb2c4);
            // await componentRepo.CreateComponent(pb1c5);
            // IList<ComponentModel> list3 = new Collection<ComponentModel>();
            // list3.Add(await componentRepo.GetComponentById(13)); //10900k
            // list3.Add(await componentRepo.GetComponentById(18)); //3090
            // list3.Add(await componentRepo.GetComponentById(38)); //asus b460
            // list3.Add(await componentRepo.GetComponentById(28)); //hyperx rgb
            // list3.Add(await componentRepo.GetComponentById(32)); //wd blue
            // list3.Add(await componentRepo.GetComponentById(42)); //nzxt
            // BuildModel pre3 = new BuildModel()
            // {
            //     AccountModelUserId = 3,
            //     Name = "Gaming Computer",
            //     ComponentList = list3
            // };
            // await buildRepo.CreateBuild(pre3);
            
            //gpu pcie 3
            // ComponentModel pcie1 = new ComponentModel()
            // {
            //     Name = "GeForce GTX 1650",
            //     Brand = "NVIDIA",
            //     ReleaseYear = "2019",
            //     Type = "GPU",
            //     SocketType = "PCIe 3.0 x16",
            //     EnergyConsumption = 75,
            //     AdditionalInfo = "1485 MHz, 4 GB GDDR5, 128 bit"
            // };
            // ComponentModel pcie2 = new ComponentModel()
            // {
            //     Name = "GeForce RTX 2060",
            //     Brand = "NVIDIA",
            //     ReleaseYear = "2018",
            //     Type = "GPU",
            //     SocketType = "PCIe 3.0 x16",
            //     EnergyConsumption = 160,
            //     AdditionalInfo = "1365 MHz, 6 GB GDDR6, 192 bit"
            // };
            // await componentRepo.CreateComponent(pcie1);
            // await componentRepo.CreateComponent(pcie2);
            
            //cpu 1151v2
            // ComponentModel cpuaa = new ComponentModel()
            // {
            //     Name = "i5-9600K",
            //     Brand = "Intel",
            //     ReleaseYear = "2018",
            //     Type = "CPU",
            //     SocketType = "1151v2",
            //     EnergyConsumption = 95,
            //     AdditionalInfo = "3.7 GHz up to 4.6 GHz, 6 cores, 6 threads"
            // };
            // ComponentModel cpubb = new ComponentModel()
            // {
            //     Name = "i7-9700K",
            //     Brand = "Intel",
            //     ReleaseYear = "2018",
            //     Type = "CPU",
            //     SocketType = "1151v2",
            //     EnergyConsumption = 95,
            //     AdditionalInfo = "3.6 GHz up to 4.9 GHz, 8 cores, 8 threads"
            // };
            // await componentRepo.CreateComponent(cpuaa);
            // await componentRepo.CreateComponent(cpubb);
            
            
            //accounts
            // AccountModel dummy1 = new AccountModel()
            // {
            //     Username = "dummy1",
            //     Password = "12345",
            //     Name = "test1"
            // };
            // AccountModel dummy2 = new AccountModel()
            // {
            //     Username = "dummy2",
            //     Password = "55555",
            //     Name = "test2"
            // };
            // await accountRepo.CreateAccount(dummy1);
            // await accountRepo.CreateAccount(dummy2);
            
            
            //posts
            // PostRepo postRepo = new PostRepo();
            // PostModel p1 = new PostModel()
            // {
            //     AccountModelUserId = 4,
            //     Content = "The United States Declaration of Independence (formally The unanimous Declaration of the thirteen united States of America) is the pronouncement adopted by the Second Continental Congress meeting in Philadelphia, Pennsylvania, on July 4, 1776.",
            // };
            // PostModel p2 = new PostModel()
            // {
            //     AccountModelUserId = 4,
            //     Content = "During his youth, Alexander was tutored by Aristotle until age 16. After Philip's assassination in 336 BC, he succeeded his father to the throne and inherited a strong kingdom and an experienced army."
            // };
            // PostModel p3 = new PostModel()
            // {
            //     AccountModelUserId = 5,
            //     Content = "Night City is an American megacity in the Free State of North California, controlled by corporations and unassailed by the laws of both country and state. It sees conflict from rampant gang wars and its ruling entities contending for dominance."
            // };
            // await postRepo.CreatePost(p1);
            // await postRepo.CreatePost(p2);
            // await postRepo.CreatePost(p3);
            
            //comments
            // CommentRepo commentRepo = new CommentRepo();
            // CommentModel c1 = new CommentModel()
            // {
            //     AccountModelUserId = 4,
            //     Content = "The most famous Egyptian pyramids are those found at Giza, on the outskirts of Cairo. Several of the Giza pyramids are counted among the largest structures ever built. The Pyramid of Khufu is the largest Egyptian pyramid.",
            //     PostModelId = 4
            // };
            // CommentModel c2 = new CommentModel()
            // {
            //     AccountModelUserId = 5,
            //     Content = "As the tanuki, the animal has been significant in Japanese folklore since ancient times. The legendary tanuki is reputed to be mischievous and jolly, a master of disguise and shapeshifting, but somewhat gullible and absentminded.",
            //     PostModelId = 3
            // };
            // await commentRepo.CreateComment(c1);
            // await commentRepo.CreateComment(c2);
            
            // AccountRepo accountRepo = new AccountRepo();
            // AccountModel accountModel = await accountRepo.GetAccountByUsername("MiauMiau");
            // Console.WriteLine(accountModel.ToString());
            // ComponentRepo componentRepo = new ComponentRepo();
            //
            // //procesoare
            // ComponentModel proc1 = new ComponentModel()
            // {
            //     Name = "Ryzen 7 5800X",
            //     Brand = "AMD",
            //     ReleaseYear = "2020",
            //     Type = "CPU",
            //     SocketType = "AM4",
            //     EnergyConsumption = 105,
            //     AdditionalInfo = "3,8 GHz up to 4.7 GHz, 8 cores, 16 threads"
            //
            // };
            // ComponentModel proc2 = new ComponentModel()
            // {
            //     Name = "Ryzen 9 5950X",
            //     Brand = "AMD",
            //     ReleaseYear = "2020",
            //     Type = "CPU",
            //     SocketType = "AM4",
            //     EnergyConsumption = 105,
            //     AdditionalInfo = "3.4 GHz up to 4.9 GHz, 16 cores, 32 threads"
            //
            // };
            // ComponentModel proc3 = new ComponentModel()
            // {
            //     Name = "Ryzen 9 5900X",
            //     Brand = "AMD",
            //     ReleaseYear = "2020",
            //     Type = "CPU",
            //     SocketType = "AM4",
            //     EnergyConsumption = 105,
            //     AdditionalInfo = "3.7 GHz up to 4.8 GHz, 12 cores, 24 threads"
            //
            // };
            // ComponentModel proc4 = new ComponentModel()
            // {
            //     Name = "Ryzen 5 5600X",
            //     Brand = "AMD",
            //     ReleaseYear = "2020",
            //     Type = "CPU",
            //     SocketType = "AM4",
            //     EnergyConsumption = 65,
            //     AdditionalInfo = "3.7 GHz up to 4.6 GHz, 6 cores, 12 threads"
            //
            // };
            // ComponentModel proc5 = new ComponentModel()
            // {
            //     Name = "i9-10850K",
            //     Brand = "Intel",
            //     ReleaseYear = "2020",
            //     Type = "CPU",
            //     SocketType = "1200 LGA",
            //     EnergyConsumption = 125,
            //     AdditionalInfo = "3.6 GHz up to 5.2 GHz, 10 cores, 20 threads"
            //
            // };
            // ComponentModel proc6 = new ComponentModel()
            // {
            //     Name = "i9-10900T",
            //     Brand = "Intel",
            //     ReleaseYear = "2020",
            //     Type = "CPU",
            //     SocketType = "1200 LGA",
            //     EnergyConsumption = 35,
            //     AdditionalInfo = "1.9 GHz up to 4.6 GHz, 10 cores, 20 threads"
            //
            // };
            // ComponentModel proc7 = new ComponentModel()
            // {
            //     Name = "i9-10900",
            //     Brand = "Intel",
            //     ReleaseYear = "2020",
            //     Type = "CPU",
            //     SocketType = "1200 LGA",
            //     EnergyConsumption = 65,
            //     AdditionalInfo = "2.8 GHz up to 5.2 GHz, 10 cores, 20 threads"
            //
            // };
            // ComponentModel proc8 = new ComponentModel()
            // {
            //     Name = "i9-10900K",
            //     Brand = "Intel",
            //     ReleaseYear = "2020",
            //     Type = "CPU",
            //     SocketType = "1200 LGA",
            //     EnergyConsumption = 125,
            //     AdditionalInfo = "3.7 GHz up to 5.3 GHz, 10 cores, 20 threads"
            //
            // };
            // ComponentModel proc9 = new ComponentModel()
            // {
            //     Name = "i9-10980HK",
            //     Brand = "Intel",
            //     ReleaseYear = "2020",
            //     Type = "CPU",
            //     SocketType = "1440 BGA",
            //     EnergyConsumption = 45,
            //     AdditionalInfo = "2.4 GHz up to 5.3 GHz, 8 cores, 16 threads"
            //
            // };
            //
            // await componentRepo.CreateComponent(proc1);
            // await componentRepo.CreateComponent(proc2);
            // await componentRepo.CreateComponent(proc3);
            // await componentRepo.CreateComponent(proc4);
            // await componentRepo.CreateComponent(proc5);
            // await componentRepo.CreateComponent(proc6);
            // await componentRepo.CreateComponent(proc7);
            // await componentRepo.CreateComponent(proc8);
            // await componentRepo.CreateComponent(proc9);
            //
            // // placi video
            // ComponentModel gpu1 = new ComponentModel()
            // {
            //     Name = "Radeon RX 6800",
            //     Brand = "AMD",
            //     ReleaseYear = "2020",
            //     Type = "GPU",
            //     SocketType = "PCIe 4.0 x16",
            //     EnergyConsumption = 250,
            //     AdditionalInfo = "1815 MHz, 16 GB GDDR6, 256 bit"
            //
            // };
            // ComponentModel gpu2 = new ComponentModel()
            // {
            //     Name = "Radeon RX 6800 XT",
            //     Brand = "AMD",
            //     ReleaseYear = "2020",
            //     Type = "GPU",
            //     SocketType = "PCIe 4.0 x16",
            //     EnergyConsumption = 300,
            //     AdditionalInfo = "2015 MHz, 16 GB GDDR6, 256 bit"
            //
            // };
            // ComponentModel gpu3 = new ComponentModel()
            // {
            //     Name = "Radeon RX 6900 XT",
            //     Brand = "AMD",
            //     ReleaseYear = "2020",
            //     Type = "GPU",
            //     SocketType = "PCIe 4.0 x16",
            //     EnergyConsumption = 300,
            //     AdditionalInfo = "2015 MHz, 16 GB GDDR6, 256 bit"
            //
            // };
            // ComponentModel gpu4 = new ComponentModel()
            // {
            //     Name = "GeForce RTX 3090",
            //     Brand = "NVIDIA",
            //     ReleaseYear = "2020",
            //     Type = "GPU",
            //     SocketType = "PCIe 4.0 x16",
            //     EnergyConsumption = 350,
            //     AdditionalInfo = "1400 MHz, 24 GB GDDR6X, 384 bit"
            //
            // };
            // ComponentModel gpu5 = new ComponentModel()
            // {
            //     Name = "GeForce RTX 3080",
            //     Brand = "NVIDIA",
            //     ReleaseYear = "2020",
            //     Type = "GPU",
            //     SocketType = "PCIe 4.0 x16",
            //     EnergyConsumption = 320,
            //     AdditionalInfo = "1440 MHz, 10 GB GDDR6X, 320 bit"
            //
            // };
            // ComponentModel gpu6 = new ComponentModel()
            // {
            //     Name = "GeForce RTX 3070",
            //     Brand = "NVIDIA",
            //     ReleaseYear = "2020",
            //     Type = "GPU",
            //     SocketType = "PCIe 4.0 x16",
            //     EnergyConsumption = 220,
            //     AdditionalInfo = "1500 MHz, 8 GB GDDR6, 256 bit"
            //
            // };
            // ComponentModel gpu7 = new ComponentModel()
            // {
            //     Name = "GeForce RTX 3060 Ti",
            //     Brand = "NVIDIA",
            //     ReleaseYear = "2020",
            //     Type = "GPU",
            //     SocketType = "PCIe 4.0 x16",
            //     EnergyConsumption = 200,
            //     AdditionalInfo = "1500 MHz, 8 GB GDDR6, 256 bit"
            // };
            //
            // await componentRepo.CreateComponent(gpu1);
            // await componentRepo.CreateComponent(gpu2);
            // await componentRepo.CreateComponent(gpu3);
            // await componentRepo.CreateComponent(gpu4);
            // await componentRepo.CreateComponent(gpu5);
            // await componentRepo.CreateComponent(gpu6);
            // await componentRepo.CreateComponent(gpu7);
            //
            // // memorie RAM
            //
            // ComponentModel ram1 = new ComponentModel()
            // {
            //     Name = "ValueRam KVR13N9K2/16",
            //     Brand = "Kingston",
            //     ReleaseYear = "2015",
            //     Type = "RAM",
            //     SocketType = "DDR3",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "2x8GB kit, DDR3-1333 CL9"
            //
            // };
            // ComponentModel ram2 = new ComponentModel()
            // {
            //     Name = "VENGEANCE RGB PRO 16",
            //     Brand = "Corsair",
            //     ReleaseYear = "2018",
            //     Type = "RAM",
            //     SocketType = "DDR4",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "2x8GB kit, DDR4-3200 CL16"
            //
            // };
            // ComponentModel ram3 = new ComponentModel()
            // {
            //     Name = "VENGEANCE RGB PRO 16",
            //     Brand = "Corsair",
            //     ReleaseYear = "2018",
            //     Type = "RAM",
            //     SocketType = "DDR4",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "2x8GB kit, DDR4-3000 CL15"
            //
            // };
            // ComponentModel ram4 = new ComponentModel()
            // {
            //     Name = "ValueRam KVR16S11K2/16",
            //     Brand = "Kingston",
            //     ReleaseYear = "2015",
            //     Type = "RAM",
            //     SocketType = "DDR3",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "2x8GB kit, DDR3-1600 CL11"
            //
            // };
            // ComponentModel ram5 = new ComponentModel()
            // {
            //     Name = "Premier 16",
            //     Brand = "ADATA",
            //     ReleaseYear = "2016",
            //     Type = "RAM",
            //     SocketType = "DDR4",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "2x8GB kit, DDR4-2400 CL17"
            //
            // };
            // ComponentModel ram6 = new ComponentModel()
            // {
            //     Name = "XPG Gammix D10",
            //     Brand = "ADATA",
            //     ReleaseYear = "2018",
            //     Type = "RAM",
            //     SocketType = "DDR4",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "2x8GB kit, DDR4-3200 CL16"
            //
            // };
            // ComponentModel ram7 = new ComponentModel()
            // {
            //     Name = "Fury RGB",
            //     Brand = "HyperX",
            //     ReleaseYear = "2019",
            //     Type = "RAM",
            //     SocketType = "DDR4",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "2x16GB kit, DDR4-3200 CL16"
            //
            // };
            // ComponentModel ram8 = new ComponentModel()
            // {
            //     Name = "Viper 4",
            //     Brand = "Patriot",
            //     ReleaseYear = "2019",
            //     Type = "RAM",
            //     SocketType = "DDR4",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "2x16GB kit, DDR4-3000 CL16"
            //
            // };
            //
            //
            // await componentRepo.CreateComponent(ram1);
            // await componentRepo.CreateComponent(ram2);
            // await componentRepo.CreateComponent(ram3);
            // await componentRepo.CreateComponent(ram4);
            // await componentRepo.CreateComponent(ram5);
            // await componentRepo.CreateComponent(ram6);
            // await componentRepo.CreateComponent(ram7);
            // await componentRepo.CreateComponent(ram8);
            //
            // //storage
            // ComponentModel stor1 = new ComponentModel()
            // {
            //     Name = "BarraCuda HDD",
            //     Brand = "Seagate",
            //     ReleaseYear = "2018",
            //     Type = "Storage",
            //     SocketType = "SATA-III",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "1TB, 7200rpm, 3.5inch"
            //
            // };
            // ComponentModel stor2 = new ComponentModel()
            // {
            //     Name = "BarraCuda HDD",
            //     Brand = "Seagate",
            //     ReleaseYear = "2018",
            //     Type = "Storage",
            //     SocketType = "SATA-III",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "1TB, 7200 rpm, 64MB buffer, 3.5inch"
            //
            // };
            // ComponentModel stor3 = new ComponentModel()
            // {
            //     Name = "Blue HDD",
            //     Brand = "WD",
            //     ReleaseYear = "2019",
            //     Type = "Storage",
            //     SocketType = "SATA-III",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "1TB, 7200 rpm, 64MB buffer, 3.5inch"
            //
            // };
            // ComponentModel stor4 = new ComponentModel()
            // {
            //     Name = "P2 SSD",
            //     Brand = "Crucial",
            //     ReleaseYear = "2017",
            //     Type = "Storage",
            //     SocketType = "NVMe",    
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "500GB, 940MB/s - 2300MB/s, M.2"
            //
            // };
            // ComponentModel stor5 = new ComponentModel()
            // {
            //     Name = "A400 SSD",
            //     Brand = "Kingston",
            //     ReleaseYear = "2018",
            //     Type = "Storage",
            //     SocketType = "SATA-III",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "240GB, 350MB/s - 500MB/s, 2.5inch"
            //
            // };
            //
            // await componentRepo.CreateComponent(stor1);
            // await componentRepo.CreateComponent(stor2);
            // await componentRepo.CreateComponent(stor3);
            // await componentRepo.CreateComponent(stor4);
            // await componentRepo.CreateComponent(stor5);
            //
            // //power supply 
            // ComponentModel supply1 = new ComponentModel()
            // {
            //     Name = "S12III-550",
            //     Brand = "Seasonic",
            //     ReleaseYear = "2018",
            //     Type = "Power supply",
            //     SocketType = "",
            //     EnergyConsumption = 550,
            //     AdditionalInfo = "85%, 80+ Bronze"
            // };
            // ComponentModel supply2 = new ComponentModel()
            // {
            //     Name = "CV650",
            //     Brand = "Corsair",
            //     ReleaseYear = "2019",
            //     Type = "Power supply",
            //     SocketType = "",
            //     EnergyConsumption = 650,
            //     AdditionalInfo = "88%, 80+ Bronze"
            // };
            // ComponentModel supply3 = new ComponentModel()
            // {
            //     Name = "System Power 9 500",
            //     Brand = "bequiet!",
            //     ReleaseYear = "2020",
            //     Type = "Power supply",
            //     SocketType = "",
            //     EnergyConsumption = 500,
            //     AdditionalInfo = "88%, 80+ Bronze"
            // };
            // ComponentModel supply4 = new ComponentModel()
            // {
            //     Name = "Power Zone 850",
            //     Brand = "bequiet!",
            //     ReleaseYear = "2020",
            //     Type = "Power supply",
            //     SocketType = "",
            //     EnergyConsumption = 850,
            //     AdditionalInfo = "88%, 80+ Bronze"
            // };
            // ComponentModel supply5 = new ComponentModel()
            // {
            //     Name = "MWE GOLD 650",
            //     Brand = "Cooler Master",
            //     ReleaseYear = "2019",
            //     Type = "Power supply",
            //     SocketType = "",
            //     EnergyConsumption = 650,
            //     AdditionalInfo = "90%, 80+ Gold, Modular"
            // };
            // ComponentModel supply6 = new ComponentModel()
            // {
            //     Name = "C750",
            //     Brand = "NZXT",
            //     ReleaseYear = "2019",
            //     Type = "Power supply",
            //     SocketType = "",
            //     EnergyConsumption = 750,
            //     AdditionalInfo = "90%, 80+ Gold, Modular"
            // };
            // await componentRepo.CreateComponent(supply1);
            // await componentRepo.CreateComponent(supply2);
            // await componentRepo.CreateComponent(supply3);
            // await componentRepo.CreateComponent(supply4);
            // await componentRepo.CreateComponent(supply5);
            // await componentRepo.CreateComponent(supply6);
            //
            //
            // //placi de baza
            // ComponentModel mb1 = new ComponentModel()
            // {
            //     Name = "B365M PRO-VH",
            //     Brand = "MSI",
            //     ReleaseYear = "2018",
            //     Type = "Motherboard",
            //     SocketType = "1151v2, PCIe 3.0 x16, DDR4, SATA-III",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "mATX"
            // };
            // ComponentModel mb2 = new ComponentModel()
            // {
            //     Name = "PRIME B460-PLUS",
            //     Brand = "ASUS",
            //     ReleaseYear = "2020",
            //     Type = "Motherboard",
            //     SocketType = "1200 LGA, PCIe 4.0 x16, DDR4, SATA-III, NVMe",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "ATX"
            // };
            // ComponentModel mb3 = new ComponentModel()
            // {
            //     Name = "B450 AORUS ELITE",
            //     Brand = "GIGABYTE",
            //     ReleaseYear = "2019",
            //     Type = "Motherboard",
            //     SocketType = "AM4, PCIe 3.0 x16, DDR4, SATA-III",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "ATX"
            // };
            // ComponentModel mb4 = new ComponentModel()
            // {
            //     Name = "X570-A PRO",
            //     Brand = "MSI",
            //     ReleaseYear = "2020",
            //     Type = "Motherboard",
            //     SocketType = "AM4, PCIe 4.0 x16, DDR4, SATA-III, NVMe",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "ATX"
            // };
            // ComponentModel mb5 = new ComponentModel()
            // {
            //     Name = "Z490-A PRO",
            //     Brand = "MSI",
            //     ReleaseYear = "2018",
            //     Type = "Motherboard",
            //     SocketType = "1200 LGA, PCIe 3.0 x16, DDR4, SATA-III",
            //     EnergyConsumption = 0,
            //     AdditionalInfo = "ATX"
            // };
            // await componentRepo.CreateComponent(mb1);
            // await componentRepo.CreateComponent(mb2);
            // await componentRepo.CreateComponent(mb3);
            // await componentRepo.CreateComponent(mb4);
            // await componentRepo.CreateComponent(mb5);
            //
            //
            //
            
            // ComponentModel c1 = new ComponentModel
            // {
            //     Id = 5,
            //     Type = "CPU",
            //     Name = "Intel i7",
            //     Brand = "Gigabyte",
            //     ReleaseYear = "2019",
            //     AdditionalInfo = "adsfasf"
            // };
            // ComponentModel c2 = new ComponentModel 
            // {
            //     Id = 4,
            //     Type = "BLABLA",
            //     Name = "Intel i7",
            //     Brand = "Gigabyte",
            //     ReleaseYear = "2019",
            //     AdditionalInfo = "fdgbhgn"
            // };
            // await componentRepo.CreateComponent(c1);
            // await componentRepo.CreateComponent(c2);

            // AccountRepo accountRepo = new AccountRepo();
            // ComponentRepo componentRepo = new ComponentRepo();
            // IList<ComponentModel> componentModels = await componentRepo.ReadComponents();
            // BuildRepo buildRepo = new BuildRepo();
            // BuildModel buildModel = new BuildModel
            // {
            //     AccountModelUserId = 6,
            //     ComponentList = componentModels,
            //     Name = "testDelete"
            // };
            // await buildRepo.CreateBuild(buildModel);
            // PostRepo postRepo = new PostRepo();
            // PostModel postModel = new PostModel
            // {
            //     AccountModelUserId = 6,
            //     Content = "dsfsa"
            // };
            // await postRepo.CreatePost(postModel);
            // CommentRepo commentRepo = new CommentRepo();
            // CommentModel commentModel = new CommentModel
            // {
            //     AccountModelUserId = 1,
            //     Content = "sadsadf",
            //     PostModelId = 4
            // };
            // await commentRepo.CreateComment(commentModel);
            // await accountRepo.DeleteAccount(6);

            // await using (Sep3DBContext context = new Sep3DBContext())
            // {
            //     CommentModel cm = await context.Comments.FirstAsync(c => c.Id == 1);
            //     Console.WriteLine(cm.ToString());
            //     PostModel pm = await context.Posts.FirstAsync(p => p.Id == 2);
            //     Console.WriteLine(pm.CommentList.ToString());
            //     if (pm.CommentList == null)
            //     {
            //         pm.CommentList = new CommentList();
            //     }
            //     pm.CommentList.AddComment(cm);
            //     context.Posts.Update(pm);
            //     await context.SaveChangesAsync();
            // }
            // ICommentRepo _commentRepo = new CommentRepo();
            // CommentModel commentModel = new CommentModel
            // {
            //     Id = 0,
            //     Content = "Yeet",
            //     DownVote = 0,
            //     UpVote = 0
            // };
            //
            // await _commentRepo.CreateComment(commentModel, 2,1);


            //
            // IPostRepo postRepo = new PostRepo();
            // PostModel postModel = new PostModel
            // {
            //     Content = "Ana are meme",
            //     DownVote = 0,
            //     UpVote = 0,
            // };
            //
            // await postRepo.CreatePost(postModel, 3);

            // CommentRepo commentRepo = new CommentRepo();
            // PostRepo postRepo = new PostRepo();
            // AccountRepo accountRepo = new AccountRepo();
            // AccountModel accountModel = new AccountModel
            // {
            //     UserId = 2,
            //     Username = "MiauMiau",
            //     Password = "98765",
            //     Name = "bonk"
            // };
            // Console.WriteLine( await accountRepo.UpdateAccount(accountModel));
            // ComponentRepo componentRepo = new ComponentRepo();
            // BuildRepo buildRepo = new BuildRepo();

            // await componentRepo.CreateComponent(c1);
            // await componentRepo.CreateComponent(c2);
            // AccountModel accountModel = new AccountModel
            // {
            //     UserId = 2,
            //     Name = "bonk",
            //     Password = "98765",
            //     Username = "MiauMiau",
            // };
            // await accountRepo.UpdateAccount(accountModel);
            // await accountRepo.CreateAccount(accountModel);

            // ComponentList componentList =new ComponentList();
            // componentList.AddComponent(c1);
            // componentList.AddComponent(c2);
            // BuildModel buildModel = new BuildModel()
            // {
            //     Name = "test1",
            // };
            // await buildRepo.CreateBuild(buildModel, componentList, 1);

            // await componentRepo.GetComponentsFromBuild(3);
            // await buildRepo.GetBuildsFromAccount(1);
            // await accountRepo.DeleteAccount(1);
            // await accountRepo.CreateAccount(accountModel);
            //
            // PostModel postModel = new PostModel
            // {
            //     UpVote = 10,
            //     DownVote = 3,
            //     Content = "adasdasda"
            // };
            // await postRepo.CreatePost(postModel,2);
            //
            // CommentModel com1 = new CommentModel
            // {
            //     UpVote = 14,
            //     DownVote = 1,
            //     Content = "adasdasda"
            // };
            // CommentModel com2 = new CommentModel
            // {
            //     UpVote = 8,
            //     DownVote = 3,
            //     Content = "adasdasda"
            // };

            // await commentRepo.GetCommentsFromPost(1);

            // await postRepo.GetPostsFromAccount(2);

            // await commentRepo.CreateComment(com1,1);
            // await commentRepo.CreateComment(com2,1);
            // ComponentList componentList =  await componentRepo.ReadComponents();

            // await accountRepo.CreateAccount(accountModel);
            // Thread.Sleep(1000);
            //
            // ComponentModel c1 = new ComponentModel
            // {
            //     Id = 2
            // };
            // ComponentModel c2 = new ComponentModel
            // {
            //     Id = 3
            // };
            // List<ComponentModel> componentModels = new List<ComponentModel>();
            // componentModels.Add(c1);
            // componentModels.Add(c2);
            // // await componentRepo.GetComponentsFromBuild(1);
            //
            // // await buildRepo.ReadBuilds(3);
            // Console.WriteLine(componentModels.Count);
            // await buildRepo.CreateBuild(buildModel, componentModels);
            //
            // BuildList list = await buildRepo.ReadBuilds(0);
            // Console.WriteLine(list);
            // Thread.Sleep(1000);
            // for (int i = 0; i < list.Size(); i++)
            // {
            //     Console.WriteLine(list.Get(1).Id);
            //     ComponentList dummyList = await componentRepo.GetComponentsFromBuild(list.Get(1).Id);
            //     Console.WriteLine(dummyList.ToString());
            // }
            // Thread.Sleep(1000);
            // Console.WriteLine(list.Get(0) + "\n" + list.Get(1));
            // Console.WriteLine(list.Get(1).BuildComponents[1] );


            // await buildRepo.CreateBuild(buildModel, componentModels);
            //Clase diferite in tier 1 si tier 2, slideurile lui Troels; Build sa aiba lista de Componente si Component lista de Builds,
            //in loc de BuildComponents; Probleme networking la castare?
            //lista de componentId ca parametru la CreateBuild



            // await accountRepo.CreateAccount(accountModel);
            // await repo.RemoveComponentFromBuild(1, 2);
            // await repo.AddComponentToBuild(1, 2);

            // SocketServer socketServer = new SocketServer();
            // socketServer.StartServer();
            // ComponentRepo c1 = new ComponentRepo();
            // c1.CreateComponent();
            // List<Component> list = c1.readComponent().Result.ToList();
            // foreach (var component in list)
            // {
            //    Console.WriteLine(component.ToString());
            // }

            // Sep3DBContext context = new Sep3DBContext();
            // BuildModel buildModel = await context.Builds.FirstAsync(b => b.Id == 1);
            // ComponentModel componentModel = await context.Components.FirstAsync(c => c.Id == 2);
            // BuildComponent buildComponent = new BuildComponent()
            // {
            //     BuildModel = buildModel,
            //     ComponentModel = componentModel
            // };
            // buildModel.BuildComponents = new List<BuildComponent>();
            // buildModel.BuildComponents.Add(buildComponent);
            // context.Update(buildModel);
            // await context.SaveChangesAsync();
            //
            // IList<BuildModel> list = context.Builds.ToList();
            // await accountRepo.AddBuilds(list, 1);
            // context.Update(accountModel);
            // await context.SaveChangesAsync();


            // AccountRepo _accountRepo = new AccountRepo();
            // ComponentRepo componentRepo = new ComponentRepo();
            // BuildRepo buildRepo = new BuildRepo();
            //
            // AccountModel accountModel = new AccountModel();
            // accountModel.UserId = 1;
            // accountModel.Username = "asasas";
            // accountModel.Password = "123";
            // accountModel.Name = "BOB";
            //


            //
            // // ComponentModel component = context.Components.First(c => c.Id == 1);
            // // Console.WriteLine(component.ToString());
            //
            // //accountModel.Builds.Add(buildModel);
            // // _accountRepo.CreateAccount(accountModel);
            // await context.Builds.AddAsync(buildModel);
            // await context.SaveChangesAsync();
        }
    }
}