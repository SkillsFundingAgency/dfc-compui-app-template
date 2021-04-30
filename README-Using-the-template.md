# dfc-compui-app-template

## Introduction - Using the template

To make use of the Visual Studio 2019 template follow the instructions in [Confluence](https://skillsfundingagency.atlassian.net/wiki/spaces/DFC/pages/1869743544/Visual+Studio+Comp+UI+Child+App+Template)

The following is an abridged version of the document from the Confluence page.

## Visual Studio Comp UI Child App Template
### Overview

This page describes how to use the Visual Studio Template to create a Comp UI Child app solution.

The VS template will create a new solution containing a number of features including:

- Web app (CompUI Child app)

- Webhook for Event Grid events

- Content cache (stored in Cosmos)

The VS template will create a new solution containing a number of projects including:

- Web app

- Cache content service

- Data/models/Contracts project

- Unit tests projects for each code project

### Create Visual Studio solution from Comp UI Template
To create a new Comp UI Child app in Visual Studio, follow the instructions below:

1. Download the template [DFC.App.Sample.zip](DFC.App.Sample.zip) file and save (do NOT unzip) to: 

*%USERPROFILE%\Documents\Visual Studio <Version>\Templates\ProjectTemplates**

2. Open Visual Studio and create new project.

3. Select **DFC.App.Sample** template - note the use of **CompUI** as a filter tag to quickly find the template.

4. Edit project's app name - replace **Sample1** with the new project name.

5. Click Create

### Post Template Use - Prepare the solution for your Child app
Once the solution has been created from the VS Template, a number of manual interventions are required in the generated source code. Please follow this sequence:

1. Copy solution files to solution folder and manually add to "**_Solution Items**" folder in the solution. These seven files may be copied from another Comp UI Child app such as SkillsFundingAgency/dfc-app-contactus. 

2. The files are:
- .gitignore
- CODEOWNERS
- DFC.Digital.CodeAnalysis.ruleset
- LICENSE
- README.md
- stylecop.json
- UnitTests.CodeAnalysis.ruleset

3. Of these files only the README.md will require any modification.

4. Close and reopen the solution - this will allow the projects to recognise the ruleset files after they have been added to the “_Solution Items” folder.

5. Edit any Json files to update the Cosmos database/collection names. (Search for "DatabaseId" and "CollectionId" and modify their values to suit your Cosmos requirements. Each child app usually has its own Cosmos database.)

6. Set the start project to the web app.

7. Adjust the value for the **WebApp BasePagesController.RegistrationPath** to match the Registration document’s **Path** value

8. Edit the **Readme.md** file to update the names/settings (search for **sample** and edit accordingly) and then change the port number to that of the web app project in the link to `https://localhost:XXXXX/pages`.

9. Review code, search for all use of the word **sample** and replace with something more suitable for your application.

10. Provision your Cosmos databases in the Cosmos Emulator to allow the app to run locally. You will need two databases, one for your app and one session state storage.

11. Edit each of the project files in the solution and add the *`<ProjectGuid>`* attribute copied from the solution file’s respective project file definition.

12. Build, test (all tests should be successful), run.

### Finished
Once the above are completed successfully, you may customise your VS solution to meet your application requirements and continue development in the usual Comp UI manner.