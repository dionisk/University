﻿using System;
using UniversityWebApplication.Exceptions;
using UniversityWebApplication.Models;
using UniversityWebApplication.Services;
using Xunit;

namespace XUnitTestProject_ToDoServices_homework4
{
    public class ToDoserviceTest
    {
        public ToDoService ToDoService { get; set; }

        void SetupProvider()
        {
            ToDoService = new ToDoService();
            ToDoService.Add(new ToDoItem {Id = 1, Name = "Make homework", Description = "just a task", CreationDate = new DateTime(2021, 01, 01), DeadLineDate = new DateTime(2022, 12, 31), Priority = 3, Status = ToDoItemStatus.Backlog, CategoryId = 1 });
            ToDoService.Add(new ToDoItem { Id = 2, Name = "Make money", Description = "nice one", CreationDate = new DateTime(2021, 01, 02), DeadLineDate = new DateTime(2022, 12, 30), Priority = 4, Status = ToDoItemStatus.Wip, CategoryId = 2 });
        }

        [Fact]
        public void AddToDoItem_PassValidData_ShouldBeOK()
        {
            //Arrange
            SetupProvider();
            ToDoItem ToDoItemWithUniqueName = new ToDoItem { Id = 3, Name = "Write good test", Description = "nice one", CreationDate = new DateTime(2021, 01, 02), DeadLineDate = new DateTime(2022, 12, 30), Priority = 4, Status = ToDoItemStatus.Wip, CategoryId = 2 };

            //Act
            ToDoService.Add(ToDoItemWithUniqueName);

            //Assert
            bool IsItemAdded = ToDoService.ToDoItemProvider.Data.Exists(t => t.Name == ToDoItemWithUniqueName.Name);
            Assert.True(IsItemAdded);
        }

        [Fact]
        public void AddToDoItem_PassDublikateName__Throws_ToDoItemProviderHasAlreadyTheSameNameException()
        {
            //Arrange
            SetupProvider();
            ToDoItem ToDoItemWithTheSameName = new ToDoItem { Id = 3, Name = "Make homework", Description = "nice one", CreationDate = new DateTime(2021, 01, 02), DeadLineDate = new DateTime(2022, 12, 30), Priority = 4, Status = ToDoItemStatus.Wip, CategoryId = 2 };

            //Act and Assert
            Assert.Throws<ToDoItemProviderHasAlreadyTheSameNameException>(() => ToDoService.Add(ToDoItemWithTheSameName));
        }

        [Fact]
        public void UpdateItem_PassValidData_ItemWithChangedNameExistsInList()
        {
            //Arrange
            SetupProvider();
            ToDoItem updatedItem = new ToDoItem { Id = 2, Name = "Make BIG money", Description = "nice one", CreationDate = new DateTime(2021, 01, 02), DeadLineDate = new DateTime(2022, 12, 30), Priority = 4, Status = ToDoItemStatus.Wip, CategoryId = 2 };

            //Act
            ToDoService.Edit(updatedItem);

            //Assert
            bool IsItemNameUpdated = ToDoService.ToDoItemProvider.Data.Exists(t => t.Name == updatedItem.Name);
            Assert.True(IsItemNameUpdated);
        }


        [Fact]
        public void UpdateItem_PassValidData_ItemWithChangedNameExistsInList_2()
        {

            // Šitas testas yra kopija aukščiau esančio testo "UpdateItem_PassValidData_ItemWithChangedNameExistsInList".
            // Tačiau jei tas testas vykdosi sėkmingai, tai šitas failina (meta NullReferenceException). Klausimas, kodėl?


            //Arrange
            SetupProvider();
            ToDoItem updatedItem = new ToDoItem { Id = 2, Name = "Make BIG money", Description = "nice one", CreationDate = new DateTime(2021, 01, 02), DeadLineDate = new DateTime(2022, 12, 30), Priority = 4, Status = ToDoItemStatus.Wip, CategoryId = 2 };

            //Act
            ToDoService.Edit(updatedItem);

            //Assert
            bool IsItemNameUpdated = ToDoService.ToDoItemProvider.Data.Exists(t => t.Name == updatedItem.Name);
            Assert.True(IsItemNameUpdated);
        }
    }
}
