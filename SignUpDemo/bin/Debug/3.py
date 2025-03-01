import cv2
import sys

# Load video file
videoPath = input("")
cap = cv2.VideoCapture(videoPath)

# Read first frame
ret, prev_frame = cap.read()

# Convert to grayscale
prev_frame_gray = cv2.cvtColor(prev_frame, cv2.COLOR_BGR2GRAY)

while True:
    # Read next frame
    ret, next_frame = cap.read()
    if not ret:
        break

    # Convert to grayscale
    next_frame_gray = cv2.cvtColor(next_frame, cv2.COLOR_BGR2GRAY)

    # Calculate absolute difference between frames
    frame_diff = cv2.absdiff(prev_frame_gray, next_frame_gray)

    # Apply threshold to get binary image
    _, thresh = cv2.threshold(frame_diff, 20, 255, cv2.THRESH_BINARY)

    # Find contours
    contours, _ = cv2.findContours(thresh, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)

    # Draw bounding boxes around moving objects
    for contour in contours:
        x, y, w, h = cv2.boundingRect(contour)
        cv2.rectangle(next_frame, (x, y), (x + w, y + h), (0, 255, 0), 2)

    # Display frame with bounding boxes
    cv2.imshow('Motion Detection', next_frame)

    # Set previous frame to current frame
    prev_frame_gray = next_frame_gray

    # Exit on ESC key press
    if cv2.waitKey(1) == 27:
        break

# Release video file and destroy windows
cap.release()
cv2.destroyAllWindows()