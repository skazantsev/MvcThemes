# MvcThemes [![Build status](https://ci.appveyor.com/api/projects/status/sda9wcvqjohgrlok?svg=true)](https://ci.appveyor.com/project/skazantsev/mvcthemes)

The application demonstrates using themes in ASP.NET MVC for building customizable web applications.

It supports customization of
* Views
* Styles
* Images

All the views are located in ***Themes/{theme_name}*** folders making the view structure as simple as it was before.

![themes structure](https://raw.github.com/skazantsev/MvcThemes/master/images/themes_structure.png)

It supports fallbacks (a view of the default theme will be used if a view for the specific one is not found), which allows you to share layouts, views and partial views and follow the DRY principle.
