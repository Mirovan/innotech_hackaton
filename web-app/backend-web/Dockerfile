FROM adoptopenjdk/openjdk11:jre-11.0.6_10-alpine
FROM maven:3.6.3-jdk-11-openj9

WORKDIR /app
COPY ./pom.xml /app
COPY ./src /app/src

RUN mvn clean package

WORKDIR /app/target
CMD ["java", "-jar", "/app/target/backend-0.0.1-SNAPSHOT.jar"]