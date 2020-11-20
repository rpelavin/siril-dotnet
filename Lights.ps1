dotnet run `
    "cd 'C:\StackBot\Multimedia\2020-11-19 Siril Example\2020-10-16 XXX40Night2Location2 376c\LIGHT'" `
    "cd 1_1" `
    "convertraw 1_1_0.25s_100g_" `
    "preprocess 1_1_0.25s_100g_ -cfa -equalize_cfa -debayer -stretch" `
    "register 1_1_0.25s_100g_" `
    "stack 1_1_0.25s_100g_ rej 3 3 -norm=addscale -out=Panel1_exposure1" `
    "cd .." `
    "exit"