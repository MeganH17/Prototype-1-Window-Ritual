// HC-SR04 pins
const int trigPin = 9;
const int echoPin = 10;

// distance range (cm)
const float minDist = 10.0;
const float maxDist = 100.0;

void setup() {
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
  Serial.begin(9600);
}

float readDistanceCM() {
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);

  long duration = pulseIn(echoPin, HIGH, 30000); // timeout
  if (duration == 0) return -1;

  return duration * 0.0343 / 2.0;
}

void loop() {
  float d = readDistanceCM();
  if (d < 0) return;

  // clamp
  d = constrain(d, minDist, maxDist);

  // normalize to 0–1
  float value = (d - minDist) / (maxDist - minDist);

  // send to Unity
  Serial.println(value, 4);

  delay(30);
}