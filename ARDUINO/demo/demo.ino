// HC-SR04 pins
#define TRIGGER_PIN 10
#define ECHO_PIN 9
#define MAX_DISTANCE 300

#include <NewPing.h>
NewPing sonar(TRIGGER_PIN, ECHO_PIN, MAX_DISTANCE);

void setup() {
  Serial.begin(9600);
}

void loop() {
  int d = sonar.ping_cm();
  if (d > 0) {
    Serial.println(d);   // 只输出数字 + 换行
  }
  delay(30);
}