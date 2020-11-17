dotnet run `
    "cd 'c:\StackBot\Multimedia\LIGHT'" `
    "cd 1_1" `
    "convertraw 1_1_0.25s_100g_" `
    "preprocess 1_1_0.25s_100g_ [-dark='this file does not exist'] -cfa -equalize_cfa -debayer -stretch" `
    "cd .." `
    "exit"