﻿using System;
using FluentAssertions;
using MethodBoundaryAspect.Fody.UnitTests.TestAssembly;
using Xunit;

namespace MethodBoundaryAspect.Fody.UnitTests
{
    public class SetMethodExecutionTagValueOnExceptionAspectTests : MethodBoundaryAspectTestBase
    {
        private static readonly Type TestClassType = typeof(SetMethodExecutionTagValueOnExceptionAspectMethods);
        
        [Fact]
        public void IfStaticMethodWithValueTypeIsCalled_ThenTheOnMethodBoundaryAspectShouldBeCalled()
        {
            // Arrange
            const string testMethodName = "StaticMethodCall";
            WeaveAssemblyMethodAndLoad(TestClassType, testMethodName);

            // Act
            var result = AssemblyLoader.InvokeMethodSwallowException(TestClassType.FullName, testMethodName);

            // Assert
            result.Should().Be("MethodExecutionTag1");
        }

        [Fact]
        public void IfInstanceMethodWithValueTypeIsCalled_ThenTheOnMethodBoundaryAspectShouldBeCalled()
        {
            // Arrange
            const string testMethodName = "InstanceMethodCall";
            WeaveAssemblyMethodAndLoad(TestClassType, testMethodName);

            // Act
            var result = AssemblyLoader.InvokeMethodSwallowException(TestClassType.FullName, testMethodName);

            // Assert
            result.Should().Be("MethodExecutionTag1");
        }
    }
}