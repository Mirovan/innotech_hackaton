package ru.bigint.webapp.config;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Configuration;
import org.springframework.core.env.Environment;
import org.springframework.web.servlet.config.annotation.ResourceHandlerRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

@Configuration
public class StaticResourceProvider implements WebMvcConfigurer {
    @Autowired
    Environment env;

    @Override
    public void addResourceHandlers(ResourceHandlerRegistry registry) {
        registry
                .addResourceHandler(env.getProperty("app.imagesHandlerPath"))
                .addResourceLocations(env.getProperty("app.imagesResourcesPath"));
    }
}