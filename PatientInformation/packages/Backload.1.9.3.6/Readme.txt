      *** IMPORTANT NOTE: 
	  Changes in Web.config and in the configuration file:
      Since version 1.9.2 the section name in Web.config has changed from name="fileUpload" to name="backload" (see below). 
      The root element must also be changed in your config file from <fileUpload> to <backload>
      The ConfigurationSection class has changed to <section type="Backload.Configuration.BackloadSection ..." />
	  Backload has implemented a fallback routine for the old schema, but it is best practice to update your config files.
	  See examples on GitHub.
	  
	  Release notes 1.9.3.6:
	  - Support for chunk uploads
	  - UNC shared folder storage improvements
	  - Optimization of memory usage (large files)
	  - Code refactoring
	  