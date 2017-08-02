# DinoDoc

DinoDoc is the &quot;Dynamic Input and Output for Documents&quot; used for SharePoint 2007, 2010, and 2013.

This small and compact utility was designed to simplify the tedious &quot;batch-uploads&quot; for SharePoint, it will help any SharePoint users to move lots of files and folders to SharePoint websites preserving the original structure from source to target, and automatically
 renaming invalid files!
 
<img src="https://github.com/MrDrSushi/DinoDoc/blob/master/docs/Documentation_dinodoc_01_main.png" alt="" width="714" height="424">

<h2>Features</h2>

DinoDoc is easy to use, all you need to do is to point to source, target and click upload (in some cases you will need to input your user id and password) and bingo! You will see DinoDoc uploading for all your files and folders from their source path to
 a new target destination in SharePoint.
 
It will rename files and folders incompatible with SharePoint naming standards, so you don't need to worry about incompatibility issues, by default SharePoint rejects files and folder with special characters and it will replace these invalid characters &quot;_&quot;,
 ?and it will also recreate the same file system structure from your local source on the destination server.
 
All operations will be logged in your screen and you can revisit everything on a separate log file (Last Operation.RTF) which you can share with you SharePoint Administrator or Help Desk Team later, if DinoDoc get a file or folder renamed it will show the
 log for the operation, as well for new/updated files/folders according to the options you have selected, you can drive DinoDoc to only perform a simulation without changing anything which is useful to generate an Impact Report before moving any external data
 into your SharePoint, other options are designed to help you to upload only new files based on their dates and sizes which is a great way to prevent upload of out dated information, and all these options can be combined for a better and robust Impact Report
