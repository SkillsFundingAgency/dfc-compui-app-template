# dfc-compui-app-template

## Introduction - Updating the template

To create / update the Visual Studio 2019 template follow the instructions in [Confluence](https://skillsfundingagency.atlassian.net/wiki/spaces/DFC/pages/1884980094/Creating+a+Visual+Studio+template+for+Comp+UI+Child+apps)

The following is an abridged version of the document from the Confluence page.

## Creating a Visual Studio template for Comp UI Child apps
### Overview
To create a new Template using Visual Studio, following the instructions below.

Guidance can be found here → https://docs.microsoft.com/en-us/visualstudio/ide/creating-project-and-item-templates?view=vs-2019

### Instructions
Use the following sequence to create a new VS Template from an existing app.

1. Select a suitable Comp UI Child app as a starting point

2. Open its solution in Visual Studio and one by one, export each project using the menu item:

- Project > Export Template

- Click Next

- Add a description if required, un-select the two check boxes and click Finish.
The new project template will be output as a Zip file to:

*%USERPROFILE%\Documents\Visual Studio <Version>\Templates\My Exported Templates*

3. Repeat for all projects to be added to the new Template.

4. Create a new working folder and move all the exported project templates (from *My Exported Templates* in step 2) into this folder and one by one use right-click > Extract All …

5. Once completed, you may delete the Zip files in the working folder as they are not required further.

6. Search for all files named **MyTemplate.vstemplate** in your working folder, there will one / sub-folder and edit each of them in turn to add the following attribute to the **TemplateData** node:

`<Hidden>true</Hidden>`

7. If you have a Web App project, edit it’s **MyTemplate.vstemplate** and replace these two nodes with the following:

```
<ProjectType>Web</ProjectType>
<ProjectSubType>CSharp</ProjectSubType>
```

8. If you have a Web App project, edit it’s **MyTemplate.vstemplate** and scroll down to find the **`<Folder Name="Properties" TargetFolderName="Properties">`** node and delete it and it’s children.

9. If you have a Web App project, delete it’s **Properties** folder.

10. Using Notepad++ or similar, replace the namespace of your original project with **`$ext_safeprojectname$`** in all *.cs & *.csproj files in the sub-folders of your working folder.

11. Click “Replace in Files” - caution - this is a one-way operation!

12. Click OK

13. Create/edit the **MyTemplate.vstemplate** file in the root of the working folder (not one in the project folders). This is used to define the solution to be created from the individual projects (in the sub-folders).

Ensure the file contains the following content.

```
<VSTemplate Version="3.0.0" xmlns="http://schemas.microsoft.com/developer/vstemplate/2005" Type="ProjectGroup">
  <TemplateData>
    <Name>DFC.App.Sample</Name>
    <Description>Comp UI Child app solution template</Description>
    <ProjectType>CSharp</ProjectType>
    <LanguageTag>C#</LanguageTag>
    <PlatformTag>windows</PlatformTag>
    <ProjectTypeTag>web</ProjectTypeTag>
    <ProjectTypeTag>CompUI</ProjectTypeTag>
  </TemplateData>
  <TemplateContent>
    <ProjectCollection>
      <SolutionFolder Name="_Solution Items">
      </SolutionFolder>
      <ProjectTemplateLink ProjectName="$safeprojectname$" CopyParameters="true">
        DFC.App.Sample\MyTemplate.vstemplate
      </ProjectTemplateLink>
      <SolutionFolder Name="Data">
        <ProjectTemplateLink ProjectName="$safeprojectname$.Data" CopyParameters="true">
          DFC.App.Sample.Data\MyTemplate.vstemplate
        </ProjectTemplateLink>
      </SolutionFolder>
      <SolutionFolder Name="Services">
        <ProjectTemplateLink ProjectName="$safeprojectname$.Services.CacheContentService" CopyParameters="true">
          DFC.App.Sample.Services.CacheContentService\MyTemplate.vstemplate
        </ProjectTemplateLink>
      </SolutionFolder>
      <SolutionFolder Name="Tests">
        <SolutionFolder Name="Unit">
          <SolutionFolder Name="Data">
            <ProjectTemplateLink ProjectName="$safeprojectname$.Data.UnitTests" CopyParameters="true">
              DFC.App.Sample.Data.UnitTests\MyTemplate.vstemplate
            </ProjectTemplateLink>
          </SolutionFolder>
          <SolutionFolder Name="Services">
            <ProjectTemplateLink ProjectName="$safeprojectname$.Services.CacheContentService.UnitTests" CopyParameters="true">
              DFC.App.Sample.Services.CacheContentService.UnitTests\MyTemplate.vstemplate
            </ProjectTemplateLink>
          </SolutionFolder>
          <SolutionFolder Name="Web">
            <ProjectTemplateLink ProjectName="$safeprojectname$.UnitTests" CopyParameters="true">
              DFC.App.Sample.UnitTests\MyTemplate.vstemplate
            </ProjectTemplateLink>
          </SolutionFolder>
        </SolutionFolder>
      </SolutionFolder>
    </ProjectCollection>
  </TemplateContent>
</VSTemplate>
```

14. Zip up all files and folders in the working folder to create the new VS Template.

15.To use the new Template, copy it to:

*%USERPROFILE%\Documents\Visual Studio <Version>\Templates\ProjectTemplates*

16. Then using Visual Studio, use create new project, search for the new template and continue as usual.