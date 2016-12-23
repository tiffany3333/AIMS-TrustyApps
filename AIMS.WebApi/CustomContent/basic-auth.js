(function () {
    $(function () {
        var apiKeyAuth = new SwaggerClient.ApiKeyAuthorization("Authorization", "Bearer 1", "header");
        window.swaggerUi.api.clientAuthorizations.add("Authorization", apiKeyAuth);
    });
})();