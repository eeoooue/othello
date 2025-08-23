
import torch.nn as nn
import torch.nn.functional as F

class ResidualBlock(nn.Module):
    def __init__(self, channels):
        super().__init__()
        self.conv1 = nn.Conv2d(channels, channels, kernel_size=3, padding=1)
        self.bn1 = nn.BatchNorm2d(channels)
        self.conv2 = nn.Conv2d(channels, channels, kernel_size=3, padding=1)
        self.bn2 = nn.BatchNorm2d(channels)
        self.dropout = nn.Dropout(p=0.3)

    def forward(self, x):
        identity = x
        out = F.relu(self.bn1(self.conv1(x)))
        out = self.bn2(self.conv2(out))
        out += identity
        out = F.relu(out)
        out = self.dropout(out)
        return out
    
class OthelloResNet(nn.Module):
    def __init__(self):
        super().__init__()
        self.conv_in = nn.Conv2d(1, 32, kernel_size=3, padding=1)
        self.bn_in = nn.BatchNorm2d(32)

        self.res1 = ResidualBlock(32)
        self.res2 = ResidualBlock(32)
        self.res3 = ResidualBlock(32)

        self.pool = nn.AdaptiveAvgPool2d((1, 1))
        self.fc1 = nn.Linear(32, 16)
        self.dropout = nn.Dropout(p=0.3)
        self.fc2 = nn.Linear(16, 1)

    def forward(self, x):
        x = F.relu(self.bn_in(self.conv_in(x)))
        x = self.res1(x)
        x = self.res2(x)
        x = self.res3(x)
        x = self.pool(x).squeeze(-1).squeeze(-1)
        x = F.relu(self.fc1(x))
        x = self.dropout(x)
        return self.fc2(x).squeeze(1)
        
