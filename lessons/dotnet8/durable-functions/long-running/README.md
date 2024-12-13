# Long Running Operations with Durable Functions (.NET 8)

## Goal 🎯

The goal of this lesson is to learn the concept of _Durable Functions_. At its core,
The Durable Functions framework introduces the concept of stateful _orchestrations_
which run one or more stateless _activities_. By managing state, checkpoints and restarts, the framework lets you focus on writing your business logic.

This lesson consists of the following exercises:

|Nr|Exercise
|-|-
|0|[Prerequisites](#0-prerequisites)
|1|[Creating a function app](#1-creating-a-function-app)
|1|[Function chaining](#2-function-chaining)
|0|[Homework](#0-homework)
|0|[More info](#0-more-info)

> 📝 **Tip** - If you're stuck at any point you can have a look at the [source code](../../../src/dotnet8/durable-functions/long-running/AzFuncUni.LongRunningTask) in this repository.

> 📝 **Tip** - If you have questions or suggestions about this lesson, feel free to [create a Lesson Q&A discussion](https://github.com/marcduiker/azure-functions-university/discussions/categories/lesson-q-a) here on GitHub.

---

## 0 - Prerequisites

| Prerequisite | Exercise
| - | -
| Azure Functions Core Tools | 1-5
| VS Code with Azure Functions extension| 1-5
| REST Client for VS Code or Postman | 1-5
| Azure Subscription | 2-5

See [.NET 8 prerequisites](../prerequisites/README.md) for more details.

## 1. Creating a Function App

In this exercise, you'll be creating a Function App with the default HTTPTrigger to serve as a startup project for subsequent exercises.

This exercise is a condensed version of the 
[HTTP Trigger (.NET 6)](../../dotnet6/http/README.md) lesson, targetting .NET 8 instead. Please, refer to that lesson for more in-depth review of the generated files and code.

### Steps

1. In VSCode, create the Function App by running `AzureFunctions: Create New Project` in the Command Palette (CTRL+SHIFT+P).
2. Browse to the location where you want to save the function app (e.g. *AzFuncUni.Logging*).
3. Select the language you'll be using to code the function, in this lesson that is using `C#`.
4. Select `.NET 8.0 Isolated LTS` as the runtime.

    If you don't see .NET 8.0, choose:

    - `Change Azure Functions version`
    - Select `Azure Functions v4`
    - Select `.NET 8.0 Isolated LTS`
>  
5. Select `HTTPTrigger` as the template.
6. Give the function a name (e.g. `HelloWorldHttpTrigger`).
7. Enter a namespace for the function (e.g. `AzFuncUni.LongRunningTask`).
8. Select `Function` for the AccessRights.

    > 🔎 **Observation** - Notice that a new project has been fully generated.

9. Build the project (CTRL+SHIFT+B).
10. Run the Function App by pressing `F5`.

    > 🔎 **Observation** - Eventually you should see a local HTTP endpoint in the output.

11. Now call the function by making a GET request to the above endpoint using a REST client:

    ```http
    GET http://localhost:7071/api/HelloWorldHttpTrigger
    ```
    > 🔎 **Observation** - You should receive a `200 OK` success response.


## 1 - Function Chaining

### Overview

Azure Functions offer a functions-as-a-service compute infrastructure that
lets users develop, run, host and manage functions in a highly scalable way.

While functions are a great way to implement a _serverless_ architecture,
most business processes will need to be composed with − and, somehow, "orchestrate" − a
set of multiple functions to achieve the desired result.

Designing such highly-scalable, fault-tolerant business processes has its own
set of challenges that can best be met by adhering to the following rough guidelines:

- Favoring stateless "pure" functions.
- Using checkpoints between steps in a business process.
- Scheduling subsequent steps by sending a message into a queue.

In the functional programming paradigm, a "pure" function is a stateless function
that does not have side effects. Given a know set of input parameters, a "pure"
function will always return the same result. Therefore, such functions offer many
benefits such as being easier to test, easier to compose and easier to include in
parallel workloads.

Writing stateless functions typically favors more fine-grained functions that
adhere to the _Single Responsibility Principle_, which makes them also easier
to reason about.

Checkpoints between steps in the business process are typically handled by
persisting state in durable storage and scheduling subsequent steps by placing
a trigger message into a queue.

![](https://learn.microsoft.com/en-us/azure/azure-functions/durable/media/durable-functions-concepts/function-chaining.png)

Building a workflow that adheres to these guidlelines by hand is represents
a significant undertaking.

The Durable Functions extension framework 

https://learn.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-orchestrations?tabs=csharp-inproc

TODO: recap and summarize the excellent introduction made in the TypeScript function
https://github.com/marcduiker/azure-functions-university/pull/252/files#diff-018a585586ec9c906cbd34dd56e7b917633e3fff277b580a2c3738863a9561f0

-> serverless + functions as a service
-> compose functions to create a more complex workflow
-> needs storage, persistence 

https://en.wikipedia.org/wiki/Function_as_a_service

-> durable functions abstract away the complexity
-> lets authors focus on writing activities

https://learn.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-overview?tabs=in-process%2Cnodejs-v3%2Cv1-model&pivots=csharp#chaining

### Steps

In this lesson, you will learn how to write a simple orchestration that
invokes two activities in sequence. The output result from the first
activity is required when invoking the second activity, thus demonstrating
the function chaining pattern.


## 0 - Homework

## 0 - More info
