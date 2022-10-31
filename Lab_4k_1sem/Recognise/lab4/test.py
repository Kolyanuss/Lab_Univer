from tensorflow.python.client import device_lib
print(device_lib.list_local_devices())

# import tensorflow as tf
# gpus = tf.config.experimental.list_physical_devices('GPU')
# print(gpus)
# tf.config.set_visible_devices([], 'CPU') # hide the CPU
# tf.config.set_visible_devices(gpus[0], 'GPU') # unhide potentially hidden GPU
# tf.config.get_visible_devices()