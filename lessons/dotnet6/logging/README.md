# Logging

## Goal 🎯

Logging is a critical part of any application and helps monitor and troubleshoot its behaviour in production. In this lesson you will learn how to log from your Function App. You will also learn how to include structured information to your logs and implement best practices for distributed tracing.

This lesson consists of the following exercises:

|Nr|Exercise
|---|---
|0|[Prerequisites](#0-prerequisites)
|1|[Creating a Function App](#1-creating-a-function-app)


> 📝 **Tip** - If you're stuck at any point you can have a look at the [source code](../../../src/dotnet6/http/AzFuncUni.Logging) in this repository.

> 📝 **Tip** - If you have questions or suggestions about this lesson, feel free to [create a Lesson Q&A discussion](https://github.com/marcduiker/azure-functions-university/discussions/categories/lesson-q-a) here on GitHub.

---

## 0. Prerequisites

| Prerequisite | Exercise
| - | -
| Azure Functions Core Tools | 1-6
| VS Code with Azure Functions extension| 1-6
| REST Client for VS Code or Postman | 1-6

See [.NET 6 prerequisites](../prerequisites/README.md) for more details.

## 1. Creating a Function App

In this exercise, you'll be creating a Function App with the default HTTPTrigger to serve as a startup project for subsequent exercises.

This exercise is a condensed version of the 
[HTTP Trigger (.NET 6)](../http/README.md) lesson. Please, refer to that lesson for more in-depth review of the generated files and code

### Steps

1. In VSCode, create the Function App by running `AzureFunctions: Create New Project` in the Command Palette (CTRL+SHIFT+P).
2. Browse to the location where you want to save the function app (e.g. *AzFuncUni.Logging*).
3. Select the language you'll be using to code the function, in this lesson that is using `C#`.
4. Select `.NET 6 Isolated LTS` as the runtime.

    If you don't see .NET 6, choose:

    - `Change Azure Functions version`
    - Select `Azure Functions v4`
    - Select `.NET 6 Isolated LTS`
>  
5. Select `HTTPTrigger` as the template.
6. Give the function a name (e.g. `HelloWorldHttpTrigger`).
7. Enter a namespace for the function (e.g. `AzFuncUni.Logging`).
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


## n. Title

In this exercise, …

### Steps

## n. Title

In this exercise, …

### Steps

## n. Title

In this exercise, …

### Steps