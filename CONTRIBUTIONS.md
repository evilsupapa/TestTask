## General overview

* This application is going to be heavy loaded so it should scale out very well. As such, resources should be used efficiently. 
	* To increase scalability, calls to the database should be asynchronous to don't block the thread executing it from doing other work (create user)
	* Manager methods call .Result on an async operation which can lead to deadlocks
	* Added index on user.login, address.country
* You may notice that the code is quite error-prone in certain places. Think about possible ways of improvement.
	* UserManager.GetByLogin gets all records then filters in memory, it also calls .First() which leads to an exception being thrown if no record is found.
* The code should never leave the database in a corrupted state.
* User Entity is an aggregate root. It is going to be extended to have more child entities later on (e.g. Phone Numbers, Document IDs). All of those don't exist without a user.
	* Added db constraints (unique login)
* Please note that multiple people will be working on this solution simultaneously. Its structure should allow for it.
	* Split main project into multiple, 
* The code should be easy to maintain and test.
* Application's API endpoints will be white-labeled (i.e. lots of third parties will be integrating with it). As such, best practices for REST API design should be considered.  
* Other mentions
	* When creating a user, avoid saving the password in plaintext (we should hash the password before saving it in the database).
## What I would have liked to implement:

A couple of unit tests, for example:
	When calling UsersController.GetById, setup userManager to return null and verify status code to be 404.
	When testing UserManager (SUT) verify that UserRepository is called with the correct parameters when creating a user - given a known password and password hash, verify that the repository method is called with the hashed password.
	HashService: given a known string, string hash and key, assert that SUT.Hash returns the known string hash
Error handling middleware to centralise exception logging.
Move sensitive data out of appsettings (connection string, keys etc.) and use environment variables.
Set UpdateAt column when updating data.