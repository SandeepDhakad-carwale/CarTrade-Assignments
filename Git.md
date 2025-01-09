# Git Assignment

 ## What i learn in Git and GitHub

 - **Version Control** 

      version control system(VCS) controls the versioning of the codes.In other words it tracking the changes in your codes.

- **Git**

   Git is a version control system that tracks changes in your code or files. It lets you save different versions of your work (commits), collaborate with others using branches, and merge changes ~. If something goes wrong, you can revert to previous versions easily.
   
- **GitHub**

   GitHub is a cloud-based platform for hosting and managing Git repositories. It allows developers to store, share, and collaborate on code projects. With features like pull requests, issue tracking, and workflows, it simplifies teamwork and project management.

- **Git vs GitHub**

  Git is a tool for version control that runs on your local machine, helping you track changes and manage code history. GitHub is a cloud-based platform that uses Git to host repositories, enabling collaboration, sharing, and remote access. Git is the engine; GitHub is the garage where you store and share your projects.


## Git commands
 - **Initialize a Repository :**
 
      `git init`

- **Check Status :** 
   
    `git status`

- **Add Files to Staging Area :**
  
  `git add <file>`
  or 
  `git add .`


- **Commit Changes:**

    `git commit -m "Commit msg"`

- **Revert a Commit:**

    `git revert <commit-hash>`

- **Create a Branch:**

  `git branch <branch-name>`

- **Switch to a Branch:**

  `git checkout <branch-name>`

- **Merge a Branch:**

   `git merge <branch-name>`

- **Clone a Repository:**

   `git clone <repository-url>`

- **Connect to a Remote Repository:**

    `git remote add origin <repository-url>`

- **Push Changes:**

   `git push origin <branch-name>`

- **Pull Changes:**

   `git pull`

- **Discard Changes:**
  
  `git checkout -- <file>`

- **View Differences:**

  `git diff`

- **Delete a Branch:**
  
  `git branch -d <branch-name>`

- **List All Branches:**

  `git branch`

  for local branches

  `git branch -a`

- **Rename a Branch:**

  `git branch -m <new-branch-name>`





## Web foundamentals

- HTTP or Hypertext Transfer Protocol is like a set of rules for how computers talk to each other on internet.
when we send sends a request to website`s computer,HTTP tells your computer how to ask for that webpage and help the  website  computer how to send it back to you.

- HTTPs  or Hypertext Transfer Protocol Secure is a secure version of HTTP that encrypts data exchanged between a browser and a server. It protects sensitive information, such as passwords and credit card details, from interception and ensures data integrity.

- The client-server model is a network architecture where a client (user device) requests services or resources, and a server (host machine) responds to those requests. The server provides data, services, or resources, while the client consumes them.

- In a client-server model, a request is sent by the client to the server asking for data or services. The response is the server's reply, providing the requested data or confirming the action.

- HTTP headers are key-value pairs sent by the client and server to exchange additional information about the request or response. These headers help control the behavior of the communication between client and server. 
  
  

- HTTP headers are classified into general, request, response, entity, and custom headers. General headers provide metadata about the communication, request headers give details about the client's request, response headers describe the server's response, and entity headers relate to the body of the request or response (e.g., content type or length).

- Common HTTP headers
  
  1. Authorization: Contains credentials for authentication (e.g., Bearer token or Basic auth).

  2. Cache-Control: Directs how the content should be cached (e.g., no-cache, max-age=3600).

  3. Content-Type: Specifies the type of data being sent (e.g., application/json, text/html)

  4. User-Agent: Identifies the client making the request (e.g., browser, OS, or device).

- HTTP request methods define the action to be taken on a resource. Common methods include GET (retrieve), POST (send data), PUT (update), DELETE (remove), and PATCH (partially update).

- HTTP response codes are three-digit numbers returned by the server to indicate the status of a request. 
- HTTP response codes are grouped into five categories: 1xx (Informational) indicates the request is being processed, 2xx (Successful) means the request was successful, 3xx (Redirection) signals the need for further action, 4xx (Client Error) indicates issues with the request, and 5xx (Server Error) points to server-side failures. Examples include 200 OK, 404 Not Found, and 500 Internal Server Error.

- Common HTTP response status code
  1. 200 OK: The request was successful, and the server responded with the requested data.
  2. 201 Created: The request was successful, and a new resource was created (typically for POST requests).
  3. 302 Found: The resource has been temporarily moved to a different URL.
  4. 400 Bad Request: The server could not understand the request due to invalid syntax.
  5. 401 Unauthorized: Authentication is required and has either failed or has not been provided.
  6. 403 Forbidden: The server understood the request but refuses to authorize it.
  7. 404 Not Found: The requested resource could not be found on the server.
 8. 500 Internal Server Error: The server encountered an unexpected condition that prevented it from fulfilling the request.



