# Use Identity to secure a Web API backend for SPAs

![image](https://github.com/ivanenkomaksym/identity-demo/assets/5527051/dfd5d63e-9c6c-4a5f-bfbd-a66116efbddc)

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


## Use token-based authentication

For clients that don't support cookies, the login API provides a parameter to request tokens. A custom token (one that is proprietary to the ASP.NET Core identity platform) is issued that can be used to authenticate subsequent requests. The token is passed in the `Authorization` header as a bearer token. A refresh token is also provided. This token allows the application to request a new token when the old one expires without forcing the user to log in again.

The tokens aren't standard JSON Web Tokens (JWTs). The use of custom tokens is intentional, as the built-in Identity API is meant primarily for simple scenarios. The token option isn't intended to be a full-featured identity service provider or token server, but instead an alternative to the cookie option for clients that can't use cookies.

To use token-based authentication, set the `useCookies` query string parameter to `false` when calling the `/login` endpoint. Tokens use the _bearer_ authentication scheme. Using the token returned from the call to `/login`, subsequent calls to protected endpoints should add the header `Authorization: Bearer <token>` where `<token>` is the access token. For more information, see [Use the `POST /login` endpoint](#use-the-post-login-endpoint) later in this article.

# References
[How to use Identity to secure a Web API backend for SPAs](https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/security/authentication/identity-api-authorization.md)
