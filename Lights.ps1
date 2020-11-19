dotnet run `
    "cd 'C:\StackBot\Multimedia\Working Files_NPM\2020-10-12thru 2020-10-19 Tucson Astro\2020-10-18 together5shots2do200 410c\LIGHT'" `
    "cd 1_1" `
    "convertraw 1_1_0.25s_100g_" `
    "preprocess 1_1_0.25s_100g_ -cfa -equalize_cfa -debayer -stretch" `
    "register 1_1_0.25s_100g_" `
    "stack 1_1_0.25s_100g_ rej 3 3 -norm=addscale -out=Panel1_exposure1" `
    "cd .." `
    "exit"