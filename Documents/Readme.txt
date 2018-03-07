//===================================================================================================
//Note 1
//===================================================================================================

Needed to add following in gitignore -

Source/Client/src/assets/fonts/*.ttf binary
Source/Client/src/assets/fonts/*.eot binary
Source/Client/src/assets/fonts/*.woff binary
Source/Client/src/assets/fonts/*.woff2 binary

*.eot binary
*.otf binary
*.ttf binary
*.woff binary
*.woff2 binary

- because if we dont add this git while uploading changes its format and than its format changes, 
  browser is unable to detect the format and gives parsing error warning.

//===================================================================================================
//Note 2
//===================================================================================================

Angular 4 does not has many open source widget which also includes datatable. No proper datatable was 
available specially server datatable, hence we needed to implement custom datatable and general 
search functionality. the same template is used across all views.

//===================================================================================================
//Note 3
//===================================================================================================

MySql does not allo pascal casing in table or database name, so needed to do following settings

Allow capital letters in MySql

C:\ProgramData\MySQL\MySQL Server 5.7

open my.ini from above location and paster following line at the bottom

lower_case_table_names = 2

//===================================================================================================
//Note 4
//===================================================================================================

Hashing strategy is used in app module, because if we dont use it than on refreshing the page gives error
page not found.
Implementing Hashing strategy takes to the same page on reload.