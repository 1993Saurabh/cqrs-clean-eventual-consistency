﻿using Ametista.Api.Controllers;
using Ametista.Api.Models;
using Ametista.Command;
using Ametista.Command.Commands;
using Ametista.Query;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Ametista.UnitTest.Controllers
{
    public class CardControllerTests
    {
        private readonly Mock<ICommandDispatcher> commandDispatcherMock;
        private readonly Mock<IQueryDispatcher> queryDispatcherMock;
        private readonly CardController controller;

        public CardControllerTests()
        {
            commandDispatcherMock = new Mock<ICommandDispatcher>();
            commandDispatcherMock
                .Setup(x => x.Dispatch(It.IsAny<CreateCardCommand>()))
                .ReturnsAsync(new CreateCardCommandResult(Guid.NewGuid(), "784789407238904742389", "Teste", DateTime.Now.Date));

            queryDispatcherMock = new Mock<IQueryDispatcher>();

            controller = new CardController(commandDispatcherMock.Object, queryDispatcherMock.Object);
        }

        [Fact]
        public async Task Post_Retuns_Response_With_Number()
        {
            // Arrange
            var request = GetResquest();

            // Act
            var response = await controller.Post(request);
            var result = Assert.IsType<OkObjectResult>(response);
            var data = Assert.IsType<CreateCardResponse>(result.Value);

            // Assert
            Assert.Equal(data.Number, request.Number);
        }

        [Fact]
        public async Task Post_Retuns_Response_With_CardHolder()
        {
            // Arrange
            var request = GetResquest();

            // Act
            var response = await controller.Post(request);
            var result = Assert.IsType<OkObjectResult>(response);
            var data = Assert.IsType<CreateCardResponse>(result.Value);

            // Assert
            Assert.Equal(data.CardHolder, request.CardHolder);
        }

        [Fact]
        public async Task Post_Retuns_Response_With_ExpirationDate()
        {
            // Arrange
            var request = GetResquest();

            // Act
            var response = await controller.Post(request);
            var result = Assert.IsType<OkObjectResult>(response);
            var data = Assert.IsType<CreateCardResponse>(result.Value);

            // Assert
            Assert.Equal(data.ExpirationDate, request.ExpirationDate);
        }

        [Fact]
        public async Task Post_Retuns_Response_With_Id()
        {
            // Arrange
            var request = GetResquest();

            // Act
            var response = await controller.Post(request);
            var result = Assert.IsType<OkObjectResult>(response);
            var data = Assert.IsType<CreateCardResponse>(result.Value);

            // Assert
            Assert.NotEqual(Guid.Empty, data.Id);
        }

        private CreateCardRequest GetResquest()
        {
            var request = new CreateCardRequest();
            request.CardHolder = "Teste";
            request.ExpirationDate = DateTime.Now.Date;
            request.Number = "784789407238904742389";

            return request;
        }
    }
}
