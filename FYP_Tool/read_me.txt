- A windows form app for image and audio steganography.
- User inputs a text message.
- Optional Huffman coding compression to reduce message size.
- Optional AES encryption to secure the message.
- Optionally compress and then encrypt the message.
- User will be able to embed the text message in an image or audio using LSB.
- Implemented calculation of quality metrics to help build dataset to train random forest model.
- User can use random forest model implemented in the app to have a knowledge on the quality of the stego media into 3 class ('good' 'accceptable' 'bad')
- Recipient can upload the received stego media and secret key to extract the embedded message.
