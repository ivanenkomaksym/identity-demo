# Use Identity to secure a Web API backend for SPAs

### Attempt to access a secured endpoint

* Run the app and navigate to the Swagger UI.
* Expand a secured endpoint, such as `/weatherforecast` in a project created by the web API template.
* Select  **Try it out**.
* Select **Execute**. The response is `401 - not authorized`.

### Test registration

* Expand `/register` and select **Try it out**.
* In the **Parameters** section of the UI, a sample request body is shown:

  ```json
  {
    "email": "string",
    "password": "string"
  }
  ```

* Replace "string" with a valid email address and password, and then select **Execute**.

  If you enter an invalid email address or a bad password, the result includes the validation errors.
  A successful registration results in a `200 - OK` response.

### Test login

* Expand `/login` and select **Try it out**. The example request body shows two additional parameters:

  ```json
  {
    "email": "string",
    "password": "string"
  }
  ```

  Set `useCookies` to `true`. 

* Replace "string" with the email address and password that you used to register, and then select **Execute**.

  A successful login results in a `200 - OK` response with a cookie in the response header.

### Retest the secured endpoint

After a successful login, rerun the secured endpoint. The authentication cookie is automatically sent with the request, and the endpoint is authorized. Cookie-based authentication is securely built-in to the browser and "just works."

# References
[How to use Identity to secure a Web API backend for SPAs](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/security/authentication/identity-api-authorization.md)
